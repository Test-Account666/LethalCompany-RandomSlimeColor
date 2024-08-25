using BepInEx.Configuration;

namespace RandomSlimeColor;

public static class ConfigManager {
    internal static ConfigEntry<float> rainbowSpeedMultiplier = null!;

    internal static void Setup(ConfigFile configFile) {
        rainbowSpeedMultiplier = configFile.Bind("General", "Rainbow Speed Multiplier", 6F,
            new ConfigDescription("Defines the multiplier that is applied to the rainbow slime's color changing",
                new AcceptableValueRange<float>(.1F, 20F)));
    }
}