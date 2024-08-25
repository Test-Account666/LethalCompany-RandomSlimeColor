using UnityEngine;

namespace RandomSlimeColor;

public class RainbowSlime : MonoBehaviour {
    private static readonly int _GradientColorProperty = Shader.PropertyToID("_Gradient_Color");
    internal BlobAI? blobAI;
    private float _hue;

    private void LateUpdate() {
        if (blobAI is null) return;

        var hueIncrement = (0.01F /*Not multiplying everything with deltaTime is a sin, so...*/ * Time.deltaTime)
                         * ConfigManager.rainbowSpeedMultiplier.Value;
        blobAI.thisSlimeMaterial.SetColor(_GradientColorProperty, Color.HSVToRGB(_hue, 1F, 1F));

        _hue += hueIncrement;

        if (_hue >= 1F) _hue = 0;
    }
}