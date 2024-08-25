using System.Collections;
using AntlerShed.SkinRegistry;
using UnityEngine;
using static AntlerShed.SkinRegistry.EnemySkinRegistry;

namespace RandomSlimeColor.Dependencies.EnemySkinRegistry;

public class RainbowSlimeColorSkin : Skin {
    public Skinner CreateSkinner() => new RainbowSlimeColorSkinner();

    public string Label => "Rainbow Color";
    public string Id => "TestAccount666.RainbowSlimeColor";
    public string EnemyId => HYGRODERE_ID;
    public Texture2D Icon => AssetLoader.rainbowColorTexture;
}

public class RainbowSlimeColorSkinner : Skinner {
    private static readonly int _GradientColorProperty = Shader.PropertyToID("_Gradient_Color");

    public Color? previousColor;

    public void Apply(GameObject enemy) {
        var blobAI = enemy.GetComponent<BlobAI>();

        blobAI.StartCoroutine(WaitAndApplySkin(blobAI));
    }

    public void Remove(GameObject enemy) {
        if (previousColor == null) return;

        var blobAi = enemy.GetComponent<BlobAI>();

        var rainbowSlime = blobAi.gameObject.AddComponent<RainbowSlime>();
        Object.Destroy(rainbowSlime);

        blobAi.thisSlimeMaterial.SetColor(_GradientColorProperty, previousColor.Value);
    }

    public IEnumerator WaitAndApplySkin(BlobAI blobAI) {
        yield return new WaitUntil(() => blobAI.thisSlimeMaterial);

        previousColor = blobAI.thisSlimeMaterial.GetColor(_GradientColorProperty);

        var rainbowSlime = blobAI.gameObject.AddComponent<RainbowSlime>();
        rainbowSlime.blobAI = blobAI;
    }
}