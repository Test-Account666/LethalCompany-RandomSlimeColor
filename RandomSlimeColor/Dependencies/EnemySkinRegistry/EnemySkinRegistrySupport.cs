using AntlerShed.SkinRegistry;
using static AntlerShed.SkinRegistry.EnemySkinRegistry;

namespace RandomSlimeColor.Dependencies.EnemySkinRegistry;

public static class EnemySkinRegistrySupport {
    public static void Initialize() {
        RegisterSkin(new RandomSlimeColorSkin(), new DefaultSkinConfigData {
            defaultEntries = [
            ],
            defaultIndoorFrequency = .75F,
            defaultOutdoorFrequency = .75F,
            vanillaFallbackIndoorFrequency = 0F,
            vanillaFallbackOutdoorFrequency = 0F,
        });

        RegisterSkin(new RainbowSlimeColorSkin(), new DefaultSkinConfigData {
            defaultEntries = [
            ],
            defaultIndoorFrequency = .25F,
            defaultOutdoorFrequency = .25F,
            vanillaFallbackIndoorFrequency = 0F,
            vanillaFallbackOutdoorFrequency = 0F,
        });
    }
}