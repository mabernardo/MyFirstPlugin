using BepInEx;
using MyFirstPlugin.Cards;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Helpers;
using InscryptionAPI.Ascension;

namespace MyFirstPlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            Logger.LogInfo("Creating cards");
            CardInfo gemPounder = GemPounder.Create();

            Logger.LogInfo("Creating Deck");
            StarterDeckInfo gemPounderDeck = ScriptableObject.CreateInstance<StarterDeckInfo>();
            gemPounderDeck.title = "GemPounder";
            gemPounderDeck.iconSprite = TextureHelper.GetImageAsSprite("starterdeck_icon_gems.png", TextureHelper.SpriteType.StarterDeckIcon);
            gemPounderDeck.cards = new() { gemPounder, CardLoader.GetCardByName("Cat"), CardLoader.GetCardByName("Wolf") };
            StarterDeckManager.Add(PluginInfo.PLUGIN_GUID, gemPounderDeck);
        }
    }
}
