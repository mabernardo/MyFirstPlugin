using DiskCardGame;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using MyFirstPlugin.Abilities;

namespace MyFirstPlugin.Cards {

    public static class GemPounder {
        public static CardInfo Create() {
            return CardManager.New(PluginInfo.PLUGIN_NAME, "GemPounder", "Gem Pounder", 1, 2)
                .SetPortrait(TextureHelper.GetImageAsTexture("portrait_copypasta.png", typeof(GemPounder).Assembly))
                .SetCost(bloodCost: 2) 
                .AddAbilities(GemScryer.AbilityID);
        }
    }
}
