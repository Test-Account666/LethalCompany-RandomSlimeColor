using System.Linq;
using BepInEx.Bootstrap;

namespace RandomSlimeColor.Dependencies;

public static class DependencyChecker {
    public static bool IsEnemySkinRegistryInstalled() =>
        Chainloader.PluginInfos.Values.Any(metadata => metadata.Metadata.GUID.Contains("antlershed.lethalcompany.enemyskinregistry"));
}