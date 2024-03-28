using HarmonyLib;
using UnityEngine;

namespace RandomSlimeColor.Patches;

[HarmonyPatch(typeof(BlobAI))]
public class BlobPatch {
    private static readonly int _GradientColorProperty = Shader.PropertyToID("_Gradient_Color");

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    [HarmonyAfter("Tomato.SCP999", "Tomato.LeanCompany")]
    // ReSharper disable once InconsistentNaming
    private static void AfterBlobStart(BlobAI __instance) {
        var colorIndex = Colors.GetRandomColorIndex();

        if (colorIndex == Colors.GetColors.Length) {
            var rainbowSlime = __instance.gameObject.AddComponent<RainbowSlime>();
            rainbowSlime.blobAI = __instance;
            return;
        }

        var color = Colors.GetColors[colorIndex];

        __instance.thisSlimeMaterial.SetColor(_GradientColorProperty, color);
    }
}