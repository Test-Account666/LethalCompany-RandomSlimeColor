using System;
using HarmonyLib;

namespace RandomSlimeColor.Patches;

[HarmonyPatch(typeof(RoundManager))]
public static class RoundManagerPatch {
    [HarmonyPatch("GenerateNewLevelClientRpc")]
    [HarmonyPostfix]
    private static void OnNewRandomSeed(int randomSeed) {
        Colors.random = new Random(randomSeed);

        RandomSlimeColor.Logger.LogInfo($"Chose new seed for slime random: {randomSeed}");
    }
}