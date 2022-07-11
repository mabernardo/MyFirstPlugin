using DiskCardGame;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstPlugin.Abilities {
    public class GemScryer : AbilityBehaviour
    {
        public override Ability Ability => AbilityID;
        public static Ability AbilityID { get; private set; }

        static GemScryer() 
        {
            AbilityInfo info = ScriptableObject.CreateInstance<AbilityInfo>();
            info.rulebookName = "Gem Scryer";
            info.rulebookDescription = "Do something cool someday";
            info.canStack = false;
            info.metaCategories = new List<AbilityMetaCategory>() { AbilityMetaCategory.Part1Rulebook };
            
            GemScryer.AbilityID = AbilityManager.Add
            (
                PluginInfo.PLUGIN_GUID,
                info,
                typeof(GemScryer),
                TextureHelper.GetImageAsTexture("ability_lifecycle.png", typeof(GemScryer).Assembly)
            ).Id;
        }
        public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
        {
            Debug.Log("card=" + card.name);
            Debug.Log("deathSlot=" + deathSlot.Index);
            Debug.Log("fromCombat=" + fromCombat);
            if (killer != null)
                Debug.Log("killer=" + killer.name);
            if (card.Info.name == "Squirrel" && fromCombat && this.Card.OnBoard) {
                CardModificationInfo cmi = new CardModificationInfo();
                cmi.healthAdjustment = 2;
                if (killer != null) {
                    killer.AddTemporaryMod(cmi);
                }
            }
            return true;
        }
    }
}