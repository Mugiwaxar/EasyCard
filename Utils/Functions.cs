using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using YamlDotNet.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace EasyCard.Utils
{
    internal class Functions
    {

        public static void CreateFileWithCardsList(string fileName, Dictionary<string, CardData> cardList)
        {
            // Create the Text File //
            StreamWriter textFile = File.CreateText("BepInEx/plugins/EasyCard/Dump/" + fileName + ".txt");
            // Write all Cards //
            foreach (KeyValuePair<string, CardData> card in cardList)
            {
                textFile.WriteLine(card.Key + " -> " + card.Value.CardName);
            }
            // Close the Text File //
            textFile.Close();
        }

        public static void CreateTextFile(string fileName, string text)
        {
            // Create the Text File //
            StreamWriter textFile = File.CreateText("BepInEx/plugins/EasyCard/Dump/VanillaCards/" + fileName + ".yaml");
            // Write the Text //
            textFile.Write(text);
            // Close the Text File //
            textFile.Close();
        }

        public static void DumpEffectsList(string fileName)
        {

            // Create the Effects Lists //
            List<string> effectPreActionList = new List<string>();
            List<string> effectCasterList = new List<string>();
            List<string> effectTrailList = new List<string>();
            List<string> effectTargetList = new List<string>();

            // Itinerate all CardData //
            foreach (KeyValuePair<string, CardData> cardData in Globals.Instance._CardsSource)
            {
                if (cardData.Value.effectPreAction != null && effectPreActionList.Contains(cardData.Value.effectPreAction) == false)
                    effectPreActionList.Add(cardData.Value.effectPreAction);
                if (cardData.Value.effectCaster != null && effectCasterList.Contains(cardData.Value.effectCaster) == false)
                    effectCasterList.Add(cardData.Value.effectCaster);
                if (cardData.Value.effectTrail != null && effectTrailList.Contains(cardData.Value.effectTrail) == false)
                    effectTrailList.Add(cardData.Value.effectTrail);
                if (cardData.Value.effectTarget != null && effectTargetList.Contains(cardData.Value.effectTarget) == false)
                    effectTargetList.Add(cardData.Value.effectTarget);
            }

            // Create the Text File //
            StreamWriter textFile = File.CreateText("BepInEx/plugins/EasyCard/Dump/" + fileName);

            // Write all EffectPreAction //
            textFile.WriteLine("------------------------------------------ EffectPreAction ------------------------------------------");
            foreach(string effect in effectPreActionList)
            {
                textFile.WriteLine(effect);
            }
            textFile.WriteLine();

            // Write all EffectCaster //
            textFile.WriteLine();            
            textFile.WriteLine("------------------------------------------ EffectCasterList ------------------------------------------");
            foreach (string effect in effectCasterList)
            {
                textFile.WriteLine(effect);
            }
            textFile.WriteLine();

            // Write all EffectTrail //
            textFile.WriteLine();
            textFile.WriteLine("------------------------------------------ EffectTrailList ------------------------------------------");
            foreach (string effect in effectTrailList)
            {
                textFile.WriteLine(effect);
            }
            textFile.WriteLine();

            // Write all EffectTarget //
            textFile.WriteLine();
            textFile.WriteLine("------------------------------------------ EffectTargetList ------------------------------------------");
            foreach (string effect in effectTargetList)
            {
                textFile.WriteLine(effect);
            }

            // Close the Text File //
            textFile.Close();

        }

        public static void DumpSoundsList(string fileName)
        {

            // Create the Sounds Lists //
            List<string> soundList = new List<string>();
            List<string> soundPreActionList = new List<string>();
            List<string> soundPreActionFemaleList = new List<string>();

            // Itinerate all CardData //
            foreach (KeyValuePair<string, CardData> cardData in Globals.Instance._CardsSource)
            {

                if (cardData.Value.sound != null && EasyCard.origSoundsList.ContainsKey(cardData.Value.sound.name) == false)
                    EasyCard.origSoundsList.Add(cardData.Value.sound.name, cardData.Value.sound);
                if (cardData.Value.soundPreAction != null && EasyCard.origSoundsList.ContainsKey(cardData.Value.soundPreAction.name) == false)
                    EasyCard.origSoundsList.Add(cardData.Value.soundPreAction.name, cardData.Value.soundPreAction);
                if (cardData.Value.soundPreActionFemale != null && EasyCard.origSoundsList.ContainsKey(cardData.Value.soundPreActionFemale.name) == false)
                    EasyCard.origSoundsList.Add(cardData.Value.soundPreActionFemale.name, cardData.Value.soundPreActionFemale);

                if (cardData.Value.sound != null && soundList.Contains(cardData.Value.sound.name) == false)
                    soundList.Add(cardData.Value.sound.name);
                if (cardData.Value.soundPreAction != null && soundPreActionList.Contains(cardData.Value.soundPreAction.name) == false)
                    soundPreActionList.Add(cardData.Value.soundPreAction.name);
                if (cardData.Value.soundPreActionFemale != null && soundPreActionFemaleList.Contains(cardData.Value.soundPreActionFemale.name) == false)
                    soundPreActionFemaleList.Add(cardData.Value.soundPreActionFemale.name);

            }

            // Create the Text File //
            StreamWriter textFile = File.CreateText("BepInEx/plugins/EasyCard/Dump/" + fileName);

            // Write all Sound //
            textFile.WriteLine("------------------------------------------ Sound ------------------------------------------");
            textFile.WriteLine();
            foreach (string sound in soundList)
            {
                textFile.WriteLine(sound);
            }
            textFile.WriteLine();

            // Write all SoundPreAction //
            textFile.WriteLine();
            textFile.WriteLine("------------------------------------------ SoundPreAction ------------------------------------------");
            textFile.WriteLine();
            foreach (string sound in soundPreActionList)
            {
                textFile.WriteLine(sound);
            }
            textFile.WriteLine();

            // Write all SoundPreActionFemale //
            textFile.WriteLine();
            textFile.WriteLine("------------------------------------------ SoundPreActionFemale ------------------------------------------");
            textFile.WriteLine();
            foreach (string sound in soundPreActionFemaleList)
            {
                textFile.WriteLine(sound);
            }

            // Close the Text File //
            textFile.Close();

        }

        public static void DumpAllAuraCurse(string fileName)
        {

            // Create the Text File //
            StreamWriter textFile = File.CreateText("BepInEx/plugins/EasyCard/Dump/" + fileName);

            // Write all Aura Curse Name //
            foreach (KeyValuePair<string, AuraCurseData> ACData in Globals.Instance._AurasCurses)
            {
                textFile.WriteLine(ACData.Key);
            }

            // Close the Text File //
            textFile.Close();

        }

        public static void DumpCard(string cardName)
        {

            // Check if the Card exist //
            if (Globals.Instance._CardsSource.ContainsKey(cardName) == false)
            {
                EasyCard.Logger.LogWarning(cardName + " doesn't exist");
                return;
            }

            // Get the Card //
            CardData cardData = Globals.Instance._CardsSource[cardName];

            // Dump the Card //
            var serializer = new SerializerBuilder().Build();
            string yaml = serializer.Serialize(cardData);
            Utils.Functions.CreateTextFile(cardData.CardName, yaml);

        }

    }
}
