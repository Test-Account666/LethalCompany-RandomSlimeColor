using UnityEngine;

namespace RandomSlimeColor.Dependencies.EnemySkinRegistry;

public static class AssetLoader {
    private static AssetBundle? _assetBundle;
    public static Texture2D randomColorTexture = null!;
    public static Texture2D rainbowColorTexture = null!;

    public static void LoadAssetBundle(string path) => _assetBundle = AssetBundle.LoadFromFile(path);

    public static void LoadAssets() {
        if (_assetBundle == null) return;

        randomColorTexture = _assetBundle.LoadAsset<Texture2D>("Assets/LethalCompany/Mods/RandomSlimeColors/RandomColorTexture.png");
        rainbowColorTexture = _assetBundle.LoadAsset<Texture2D>("Assets/LethalCompany/Mods/RandomSlimeColors/RainbowColorTexture.png");
    }
}