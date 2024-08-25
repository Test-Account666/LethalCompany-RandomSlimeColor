using System.Collections;
using AntlerShed.SkinRegistry;
using UnityEngine;
using static AntlerShed.SkinRegistry.EnemySkinRegistry;

namespace RandomSlimeColor.Dependencies.EnemySkinRegistry;

public class RandomSlimeColorSkin : Skin {
    public Skinner CreateSkinner() => new RandomSlimeColorSkinner();

    public string Label => "Random Color";
    public string Id => "TestAccount666.RandomSlimeColor";
    public string EnemyId => HYGRODERE_ID;
    public Texture2D Icon => AssetLoader.randomColorTexture;
}

public class RandomSlimeColorSkinner : Skinner {
    private static readonly int _GradientColorProperty = Shader.PropertyToID("_Gradient_Color");

    public Color? previousColor;

    public void Apply(GameObject enemy) {
        var blobAI = enemy.GetComponent<BlobAI>();

        blobAI.StartCoroutine(WaitAndApplySkin(blobAI));
    }

    public void Remove(GameObject enemy) {
        if (previousColor == null) return;

        var blobAi = enemy.GetComponent<BlobAI>();

        blobAi.thisSlimeMaterial.SetColor(_GradientColorProperty, previousColor.Value);
    }

    public IEnumerator WaitAndApplySkin(BlobAI blobAI) {
        yield return new WaitUntil(() => blobAI.thisSlimeMaterial);

        previousColor = blobAI.thisSlimeMaterial.GetColor(_GradientColorProperty);

        var colorIndex = Colors.GetRandomColorIndexWithoutRainbow();

        var color = Colors.GetColors[colorIndex];

        blobAI.thisSlimeMaterial.SetColor(_GradientColorProperty, color);
    }
}