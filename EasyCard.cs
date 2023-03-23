using BepInEx;
using BepInEx.Logging;
using EasyCard.CardsManager;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace EasyCard
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class EasyCard : BaseUnityPlugin
    {

        private const string ModGUID = "Dexy-EasyCard";
        private const string ModName = "EasyCard";
        private const string ModVersion = "0.0.1";
        internal static new ManualLogSource Logger { get; set; }

        public static Dictionary<string, AudioClip> origSoundsList = new Dictionary<string, AudioClip>();

        private void Awake()
        {

            // Get the BepInEx Logger //
            EasyCard.Logger = base.Logger;

            // Log the Start of the Plugin //
            Logger.LogInfo("Plugin EasyCard Added!");

            // Create Hooks //
            Utils.Hooks.AddHooks(typeof(Globals), nameof(Globals.CreateCardClones), RetrieveCardsList);

        }

        private static void RetrieveCardsList(Action<Globals> orig, Globals self)
        {

            // Dump all Effects of the Game inside a Text File //
            Utils.Functions.DumpEffectsList("EffectsList.txt");

            // Dump all Sounds of the Game inside a Text File //
            Utils.Functions.DumpSoundsList("SoundsList.txt");

            // Dump all Cards inside a Text File //
            Utils.Functions.CreateFileWithCardsList("OriginalCardsList", self._CardsSource);

            // Dump all AuraCurse //
            Utils.Functions.DumpAllAuraCurse("AuraCurse.txt");

            // Dump selected Cards //
            //foreach (KeyValuePair<string, CardData> cardData in Globals.Instance._CardsSource)
            //{
            //    if (cardData.Value.id == "innercombustion")
            //        Utils.Functions.DumpCard(cardData.Key);
            //}

            // Add all news Cards //
            CardsManager.AddCards.ProcessAdd(self._CardsSource);

            // Launch the Original Function //
            orig(self);

            // Re-Dump all Cards inside a Text File //
            Utils.Functions.CreateFileWithCardsList("ModedCardsList", self._CardsSource);

        }

    }
}