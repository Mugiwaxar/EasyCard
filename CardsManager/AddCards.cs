using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace EasyCard.CardsManager
{
    internal class AddCards
    {

        public static void ProcessAdd(Dictionary<string, CardData> cardsList)
        {

            // Create the Cards List //
            Dictionary<string, ECCard> newCards = new Dictionary<string, ECCard>();

            // Get all Cards File from Disk //
            string[] filePaths = Directory.GetFiles("./BepInEx/plugins/EasyCard/AddedCards/");

            // Create the Deserializer //
            var deserializer = new DeserializerBuilder().Build();

            // Load all Cards //
            foreach (string filePath in filePaths)
            {
                string textCard = File.ReadAllText(filePath);
                ECCard newCard = deserializer.Deserialize<ECCard>(textCard);
                newCard.FilePath = filePath;
                if (newCard.id != null)
                    newCards.Add(newCard.id, newCard);
            }

            // Add all Cards to the Game Cards List //
            foreach(KeyValuePair<string, ECCard> ecCardPair in newCards)
            {
                CardData cardData = ecCardPair.Value.formatCard();
                if (cardData != null)
                {
                    Globals.Instance._CardsSource.Add(cardData.id, cardData);
                    EasyCard.Logger.LogInfo("Added Card \"" + cardData.CardName + "\" to the Game!");
                }
            }

        }


        public static CardData CreateTestCard()
        {
            // Create a Card that will replace missing Cards //
            CardData cardData = ScriptableObject.CreateInstance<CardData>();
            cardData.id = "test_card";
            cardData.name = "TestCard";
            cardData.CardName = "Test Card";
            cardData.descriptionId = "easycard_" + cardData.id;

            // Add the Description //
            string description = "This is a test!";
            Texts.Instance.TextStrings[Globals.Instance.CurrentLang].Add(cardData.descriptionId, description);


            return cardData;
        }


    }
}
