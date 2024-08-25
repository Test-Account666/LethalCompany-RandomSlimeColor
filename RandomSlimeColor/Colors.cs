using UnityEngine;
using Random = System.Random;

namespace RandomSlimeColor;

public static class Colors {
    internal static Random random = new();

    internal static readonly Color[] GetColors = [
        Color.black, Color.white, Color.blue, Color.green, Color.cyan, Color.gray, Color.magenta, Color.red,
        Color.yellow
    ];

    internal static int GetRandomColorIndex() => random.Next(0, GetColors.Length + 1);
    
    internal static int GetRandomColorIndexWithoutRainbow() => random.Next(0, GetColors.Length);
}