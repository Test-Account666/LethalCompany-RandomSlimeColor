using System.Diagnostics;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RandomSlimeColor.Dependencies;
using RandomSlimeColor.Dependencies.EnemySkinRegistry;
using RandomSlimeColor.Patches;

namespace RandomSlimeColor;

[BepInDependency("antlershed.lethalcompany.enemyskinregistry", BepInDependency.DependencyFlags.SoftDependency)]
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class RandomSlimeColor : BaseUnityPlugin {
    public static RandomSlimeColor Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger { get; private set; } = null!;
    internal static Harmony? Harmony { get; set; }
    private static bool _enemyRegistryInstalled;

    private void Awake() {
        Logger = base.Logger;
        Instance = this;

        ConfigManager.Setup(Config);

        _enemyRegistryInstalled = DependencyChecker.IsEnemySkinRegistryInstalled();

        Patch();

        if (_enemyRegistryInstalled) {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyDirectory = Path.GetDirectoryName(assembly.Location);

            Debug.Assert(assemblyDirectory != null, nameof(assemblyDirectory) + " != null");
            var assetLocation = Path.Combine(assemblyDirectory, "randomslimecolor");

            AssetLoader.LoadAssetBundle(assetLocation);
            AssetLoader.LoadAssets();

            EnemySkinRegistrySupport.Initialize();
        }

        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
    }

    internal static void Patch() {
        Harmony ??= new(MyPluginInfo.PLUGIN_GUID);

        Logger.LogDebug("Patching...");

        Harmony.PatchAll(typeof(RoundManagerPatch));

        if (!_enemyRegistryInstalled) Harmony.PatchAll(typeof(BlobPatch));

        Logger.LogDebug("Finished patching!");
    }

    // I'll never delete this, hehe
    //TODO: Ping @Jandert when finished
}