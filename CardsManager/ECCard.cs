using EasyCard.TempObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using static Enums;

namespace EasyCard.CardsManager
{
    internal class ECCard
    {

        #pragma warning disable 0649
        public string FilePath;
        public string cardName;
        public string id;
        public string upgradesTo1;
        public string upgradesTo2;
        public CardUpgraded CardUpgraded;
        public string UpgradedFrom;
        public string baseCard;
        public string upgradesToRare;
        public string description;
        public string fluff;
        public float fluffPercent;
        public string relatedCard;
        public List<DerivedKeyNotesData> keyNotes;
        public string sprite;
        public bool flipSprite;
        public bool showInTome;
        public int maxInDeck;
        public CardRarity cardRarity;
        public CardType cardType;
        public CardType[] cardTypeAux;
        public CardClass cardClass;
        public int energyCost;
        public bool playable;
        public bool autoplayDraw;
        public bool autoplayEndTurn;
        public string effectRequired;
        public bool vanish;
        public bool innate;
        public bool lazy;
        public bool endTurn;
        public bool moveToCenter;
        public bool corrupted;
        public bool starter;
        public CardTargetType targetType;
        public CardTargetSide targetSide;
        public CardTargetPosition targetPosition;
        public CardSpecialValue specialValueGlobal;
        public string specialAuraCurseNameGlobal;
        public float specialValueModifierGlobal;
        public CardSpecialValue specialValue1;
        public string specialAuraCurseName1;
        public float specialValueModifier1;
        public CardSpecialValue specialValue2;
        public string specialAuraCurseName2;
        public float specialValueModifier2;
        public int effectRepeat;
        public float effectRepeatDelay;
        public int effectRepeatEnergyBonus;
        public int effectRepeatMaxBonus;
        public EffectRepeatTarget effectRepeatTarget;
        public int effectRepeatModificator;
        public DamageType damageType;
        public int damage;
        public int damageSides;
        public int damageSelf;
        public bool damageSpecialValueGlobal;
        public bool damageSpecialValue1;
        public bool damageSpecialValue2;
        public bool ignoreBlock;
        public DamageType damageType2;
        public int damage2;
        public int damageSides2;
        public int damageSelf2;
        public bool damage2SpecialValueGlobal;
        public bool damage2SpecialValue1;
        public bool damage2SpecialValue2;
        public bool ignoreBlock2;
        public int selfHealthLoss;
        public bool selfHealthLossSpecialGlobal;
        public bool selfHealthLossSpecialValue1;
        public bool selfHealthLossSpecialValue2;
        public int damageEnergyBonus;
        public string acEnergyBonus;
        public int acEnergyBonusQuantity;
        public string acEnergyBonus2;
        public int acEnergyBonus2Quantity;
        public int heal;
        public int healSides;
        public int healSelf;
        public int healEnergyBonus;
        public float healSelfPerDamageDonePercent;
        public bool healSpecialValueGlobal;
        public bool healSpecialValue1;
        public bool healSpecialValue2;
        public bool healSelfSpecialValueGlobal;
        public bool healSelfSpecialValue1;
        public bool healSelfSpecialValue2;
        public int healCurses;
        public int dispelAuras;
        public int transferCurses;
        public int stealAuras;
        public int reduceCurses;
        public int reduceAuras;
        public int increaseCurses;
        public int increaseAuras;
        public string healAuraCurseSelf;
        public string healAuraCurseName;
        public string healAuraCurseName2;
        public string healAuraCurseName3;
        public string healAuraCurseName4;
        public int energyRecharge;
        public string aura;
        public string auraSelf;
        public int auraCharges;
        public bool auraChargesSpecialValueGlobal;
        public bool auraChargesSpecialValue1;
        public bool auraChargesSpecialValue2;
        public string aura2;
        public string auraSelf2;
        public int auraCharges2;
        public bool auraCharges2SpecialValueGlobal;
        public bool auraCharges2SpecialValue1;
        public bool auraCharges2SpecialValue2;
        public string aura3;
        public string auraSelf3;
        public int auraCharges3;
        public bool auraCharges3SpecialValueGlobal;
        public bool auraCharges3SpecialValue1;
        public bool auraCharges3SpecialValue2;
        public string curse;
        public string curseSelf;
        public int curseCharges;
        public bool curseChargesSpecialValueGlobal;
        public bool curseChargesSpecialValue1;
        public bool curseChargesSpecialValue2;
        public string curse2;
        public string curseSelf2;
        public int curseCharges2;
        public bool curseCharges2SpecialValueGlobal;
        public bool curseCharges2SpecialValue1;
        public bool curseCharges2SpecialValue2;
        public string curse3;
        public string curseSelf3;
        public int curseCharges3;
        public bool curseCharges3SpecialValueGlobal;
        public bool curseCharges3SpecialValue1;
        public bool curseCharges3SpecialValue2;
        public int drawCard;
        public int discardCard;
        public CardType discardCardType;
        public CardType[] discardCardTypeAux;
        public bool discardCardAutomatic;
        public CardPlace discardCardPlace;
        public int addCard;
        public string addCardId;
        public CardType addCardType;
        public CardType[] addCardTypeAux;
        public List<string> addCardList;
        public int addCardChoose;
        public CardFrom addCardFrom;
        public CardPlace addCardPlace;
        public int addCardReducedCost;
        public bool addCardCostTurn;
        public bool addCardVanish;
        public int lookCards;
        public int lookCardsDiscardUpTo;
        public int lookCardsVanishUpTo;
        public string sound;
        public string soundPreAction;
        public string soundPreActionFemale;
        public string effectPreAction;
        public bool effectCasterRepeat;
        public float effectPostCastDelay;
        public bool effectCastCenter;
        public string effectCaster;
        public string effectTrail;
        public bool effectTrailRepeat;
        public float effectTrailSpeed;
        public EffectTrailAngle effectTrailAngle;
        public string effectTarget;
        public float effectPostTargetDelay;
        #pragma warning restore 0649

        public CardData formatCard()
        {
            // Check the Card ID //
            if (this.id == null)
            {
                EasyCard.Logger.LogWarning("Unable to add Card \"" + FilePath + "\". CardID is null.");
                return null;
            }

            // Check the Card Name //
            if (this.cardName == null)
            {
                EasyCard.Logger.LogWarning("Unable to add Card \"" + FilePath + "\". Name is null.");
                return null;
            }

            // Get all Information //
            CardData cardData = ScriptableObject.CreateInstance<CardData>();
            cardData.name = this.cardName;
            cardData.cardName = this.cardName;
            cardData.id = this.id.ToLower();
            cardData.upgradesTo1 = this.upgradesTo1;
            cardData.upgradesTo2 = this.upgradesTo2;
            cardData.CardUpgraded = this.CardUpgraded;
            cardData.UpgradedFrom = this.UpgradedFrom;
            cardData.baseCard = this.baseCard;
            if (this.upgradesToRare != null) cardData.upgradesToRare = Globals.Instance.GetCardData(this.upgradesToRare, false);
            cardData.description = this.description;
            if (this.description != null) cardData.descriptionId = "easycard_" + this.id.ToLower();
            if (this.description != null) Texts.Instance.TextStrings[Globals.Instance.CurrentLang].Add(cardData.descriptionId, this.description);
            cardData.fluff = this.fluff;
            cardData.fluffPercent = this.fluffPercent;
            cardData.relatedCard = this.relatedCard;
            cardData.keyNotes = DerivedKeyNotesData.createKeysNotesDatas(this.keyNotes);
            cardData.sprite = loadSprite(sprite, cardData.name);
            cardData.flipSprite = this.flipSprite;
            cardData.showInTome = this.showInTome;
            cardData.maxInDeck = this.maxInDeck;
            cardData.CardRarity = this.cardRarity;
            cardData.cardType = this.cardType;
            cardData.cardTypeAux = this.cardTypeAux;
            cardData.cardClass = this.cardClass;
            cardData.energyCost = this.energyCost;
            cardData.playable = this.playable;
            cardData.autoplayDraw = this.autoplayDraw;
            cardData.autoplayEndTurn = this.autoplayEndTurn;
            cardData.effectRequired = this.effectRequired;
            cardData.vanish = this.vanish;
            cardData.innate = this.innate;
            cardData.lazy = this.lazy;
            cardData.endTurn = this.endTurn;
            cardData.moveToCenter = this.moveToCenter;
            cardData.corrupted = this.corrupted;
            cardData.starter = this.starter;
            cardData.targetType = this.targetType;
            cardData.targetSide = this.targetSide;
            cardData.targetPosition = this.targetPosition;
            cardData.specialValueGlobal = this.specialValueGlobal;
            if (this.specialAuraCurseNameGlobal != null) cardData.specialAuraCurseNameGlobal = Globals.Instance.GetAuraCurseData(this.specialAuraCurseNameGlobal);
            cardData.specialValueModifierGlobal = this.specialValueModifierGlobal;
            cardData.specialValue1 = this.specialValue1;
            if (this.specialAuraCurseName1 != null) cardData.specialAuraCurseName1 = Globals.Instance.GetAuraCurseData(this.specialAuraCurseName1);
            cardData.specialValueModifier1 = this.specialValueModifier1;
            cardData.specialValue2 = this.specialValue2;
            if (this.specialAuraCurseName2 != null) cardData.specialAuraCurseName2 = Globals.Instance.GetAuraCurseData(this.specialAuraCurseName2);
            cardData.specialValueModifier2 = this.specialValueModifier2;
            cardData.effectRepeat = this.effectRepeat;
            cardData.effectRepeatDelay = this.effectRepeatDelay;
            cardData.effectRepeatEnergyBonus = this.effectRepeatEnergyBonus;
            cardData.effectRepeatMaxBonus = this.effectRepeatMaxBonus;
            cardData.effectRepeatTarget = this.effectRepeatTarget;
            cardData.effectRepeatModificator = this.effectRepeatModificator;
            cardData.damageType = this.damageType;
            cardData.damage = this.damage;
            cardData.damageSides = this.damageSides;
            cardData.damageSelf = this.damageSelf;
            cardData.damageSpecialValueGlobal = this.damageSpecialValueGlobal;
            cardData.damageSpecialValue1 = this.damageSpecialValue1;
            cardData.damageSpecialValue2 = this.damageSpecialValue2;
            cardData.ignoreBlock = this.ignoreBlock;
            cardData.damageType2 = this.damageType2;
            cardData.damage2 = this.damage2;
            cardData.damageSides2 = this.damageSides2;
            cardData.damageSelf2 = this.damageSelf2;
            cardData.damage2SpecialValueGlobal = this.damage2SpecialValueGlobal;
            cardData.damage2SpecialValue1 = this.damage2SpecialValue1;
            cardData.damage2SpecialValue2 = this.damage2SpecialValue2;
            cardData.ignoreBlock2 = this.ignoreBlock2;
            cardData.selfHealthLoss = this.selfHealthLoss;
            cardData.selfHealthLossSpecialGlobal = this.selfHealthLossSpecialGlobal;
            cardData.selfHealthLossSpecialValue1 = this.selfHealthLossSpecialValue1;
            cardData.selfHealthLossSpecialValue2 = this.selfHealthLossSpecialValue2;
            cardData.damageEnergyBonus = this.damageEnergyBonus;
            if (this.acEnergyBonus != null) cardData.acEnergyBonus = Globals.Instance.GetAuraCurseData(this.acEnergyBonus);
            cardData.acEnergyBonusQuantity = this.acEnergyBonusQuantity;
            if (this.acEnergyBonus2 != null) cardData.acEnergyBonus2 = Globals.Instance.GetAuraCurseData(this.acEnergyBonus2);
            cardData.acEnergyBonus2Quantity = this.acEnergyBonus2Quantity;
            cardData.heal = this.heal;
            cardData.healSides = this.healSides;
            cardData.healSelf = this.healSelf;
            cardData.healSelfPerDamageDonePercent = this.healSelfPerDamageDonePercent;
            cardData.healEnergyBonus = this.healEnergyBonus;
            cardData.healSpecialValueGlobal = this.healSpecialValueGlobal;
            cardData.healSpecialValue1 = this.healSpecialValue1;
            cardData.healSpecialValue2 = this.healSpecialValue2;
            cardData.healSelfSpecialValueGlobal = this.healSelfSpecialValueGlobal;
            cardData.healSelfSpecialValue1 = this.healSelfSpecialValue1;
            cardData.healSelfSpecialValue2 = this.healSelfSpecialValue2;
            cardData.healCurses = this.healCurses;
            cardData.dispelAuras = this.dispelAuras;
            cardData.transferCurses = this.transferCurses;
            cardData.stealAuras = this.stealAuras;
            cardData.reduceCurses = this.reduceCurses;
            cardData.reduceAuras = this.reduceAuras;
            cardData.increaseCurses = this.increaseCurses;
            cardData.increaseAuras = this.increaseAuras;
            if (this.healAuraCurseSelf != null) cardData.healAuraCurseSelf = Globals.Instance.GetAuraCurseData(this.healAuraCurseSelf);
            if (this.healAuraCurseName != null) cardData.healAuraCurseName = Globals.Instance.GetAuraCurseData(this.healAuraCurseName);
            if (this.healAuraCurseName2 != null) cardData.healAuraCurseName2 = Globals.Instance.GetAuraCurseData(this.healAuraCurseName2);
            if (this.healAuraCurseName3 != null) cardData.healAuraCurseName3 = Globals.Instance.GetAuraCurseData(this.healAuraCurseName3);
            if (this.healAuraCurseName4 != null) cardData.healAuraCurseName4 = Globals.Instance.GetAuraCurseData(this.healAuraCurseName4);
            cardData.energyRecharge = this.energyRecharge;
            if (this.aura != null) cardData.aura = Globals.Instance.GetAuraCurseData(this.aura);
            if (this.auraSelf != null) cardData.auraSelf = Globals.Instance.GetAuraCurseData(this.auraSelf);
            cardData.auraCharges = this.auraCharges;
            cardData.auraChargesSpecialValueGlobal = this.auraChargesSpecialValueGlobal;
            cardData.auraChargesSpecialValue1 = this.auraChargesSpecialValue1;
            cardData.auraChargesSpecialValue2 = this.auraChargesSpecialValue2;
            if (this.aura2 != null) cardData.aura2 = Globals.Instance.GetAuraCurseData(this.aura2);
            if (this.auraSelf2 != null) cardData.auraSelf2 = Globals.Instance.GetAuraCurseData(this.auraSelf2);
            cardData.auraCharges2 = this.auraCharges2;
            cardData.auraCharges2SpecialValueGlobal = this.auraCharges2SpecialValueGlobal;
            cardData.auraCharges2SpecialValue1 = this.auraCharges2SpecialValue1;
            cardData.auraCharges2SpecialValue2 = this.auraCharges2SpecialValue2;
            if (this.aura3 != null) cardData.aura3 = Globals.Instance.GetAuraCurseData(this.aura3);
            if (this.auraSelf3 != null) cardData.auraSelf3 = Globals.Instance.GetAuraCurseData(this.auraSelf3);
            cardData.auraCharges3 = this.auraCharges3;
            cardData.auraCharges3SpecialValueGlobal = this.auraCharges3SpecialValueGlobal;
            cardData.auraCharges3SpecialValue1 = this.auraCharges3SpecialValue1;
            cardData.auraCharges3SpecialValue2 = this.auraCharges3SpecialValue2;
            if (this.curse != null) cardData.curse = Globals.Instance.GetAuraCurseData(this.curse);
            if (this.curseSelf != null) cardData.curseSelf = Globals.Instance.GetAuraCurseData(this.curseSelf);
            cardData.curseCharges = this.curseCharges;
            cardData.curseChargesSpecialValueGlobal = this.curseChargesSpecialValueGlobal;
            cardData.curseChargesSpecialValue1 = this.curseChargesSpecialValue1;
            cardData.curseChargesSpecialValue2 = this.curseChargesSpecialValue2;
            if (this.curse2 != null) cardData.curse2 = Globals.Instance.GetAuraCurseData(this.curse2);
            if (this.curseSelf2 != null) cardData.curseSelf2 = Globals.Instance.GetAuraCurseData(this.curseSelf2);
            cardData.curseCharges2 = this.curseCharges2;
            cardData.curseCharges2SpecialValueGlobal = this.curseCharges2SpecialValueGlobal;
            cardData.curseCharges2SpecialValue1 = this.curseCharges2SpecialValue1;
            cardData.curseCharges2SpecialValue2 = this.curseCharges2SpecialValue2;
            if (this.curse3 != null) cardData.curse3 = Globals.Instance.GetAuraCurseData(this.curse3);
            if (this.curseSelf3 != null) cardData.curseSelf3 = Globals.Instance.GetAuraCurseData(this.curseSelf3);
            cardData.curseCharges3 = this.curseCharges3;
            cardData.curseCharges3SpecialValueGlobal = this.curseCharges3SpecialValueGlobal;
            cardData.curseCharges3SpecialValue1 = this.curseCharges3SpecialValue1;
            cardData.curseCharges3SpecialValue2 = this.curseCharges3SpecialValue2;
            cardData.drawCard = this.drawCard;
            cardData.discardCard = this.discardCard;
            cardData.discardCardType = this.discardCardType;
            cardData.discardCardTypeAux = this.discardCardTypeAux;
            cardData.discardCardAutomatic = this.discardCardAutomatic;
            cardData.discardCardPlace = this.discardCardPlace;
            cardData.addCard = this.addCard;
            cardData.addCardId = this.addCardId;
            cardData.addCardType = this.addCardType;
            cardData.addCardTypeAux = this.addCardTypeAux;
            if (this.addCardList != null) cardData.addCardList = this.cardStingsToList(this.addCardList);
            cardData.addCardChoose = this.addCardChoose;
            cardData.addCardFrom = this.addCardFrom;
            cardData.addCardPlace = this.addCardPlace;
            cardData.addCardReducedCost = this.addCardReducedCost;
            cardData.addCardCostTurn = this.addCardCostTurn;
            cardData.addCardVanish = this.addCardVanish;
            cardData.lookCards = this.lookCards;
            cardData.lookCardsDiscardUpTo = this.lookCardsDiscardUpTo;
            cardData.sound = this.getAudioClip(this.sound);
            cardData.soundPreAction = this.getAudioClip(this.soundPreAction);
            cardData.soundPreActionFemale = this.getAudioClip(this.soundPreActionFemale);
            cardData.effectPreAction = this.effectPreAction;
            cardData.effectCaster = this.effectCaster;
            cardData.effectCasterRepeat = this.effectCasterRepeat;
            cardData.effectPostCastDelay = this.effectPostCastDelay;
            cardData.effectCastCenter = this.effectCastCenter;
            cardData.effectTrail = this.effectTrail;
            cardData.effectTrailRepeat = this.effectTrailRepeat;
            cardData.effectTrailSpeed = this.effectTrailSpeed;
            cardData.effectTrailAngle = this.effectTrailAngle;
            cardData.effectTarget = this.effectTarget;
            cardData.effectPostTargetDelay = this.effectPostTargetDelay;

            // Return the Card Data //
            return cardData;

        }

        public Sprite loadSprite(string fileName, string cardName)
        {

            // Check if they is a FileName //
            if (fileName == null) return null;

            // Create the Path //
            string completePath = "./BepInEx/plugins/EasyCard/Images/" + fileName;

            // Check if the File Exist //
            if (File.Exists(completePath) == false)
            {
                EasyCard.Logger.LogWarning("Unable to load Image for Card \"" + cardName + "\". File doesn't exist: " + completePath);
                return null;
            }

            // Get the Sprite //
            byte[] rawData = File.ReadAllBytes(completePath);
            Texture2D texture = new Texture2D(0, 0);
            texture.LoadImage(rawData);
            texture.filterMode = FilterMode.Point;
            Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f, 0, SpriteMeshType.FullRect);
           
            // Return the Sprite //
            return sprite;

        }

        public AudioClip getAudioClip(string soundName)
        {
            // Check the String //
            if (soundName == null) return null;
            // Check if the Sound Name can be found inside the created Sound List //
            if (EasyCard.origSoundsList.ContainsKey(soundName))
            {
                return EasyCard.origSoundsList[soundName];
            }
            else
            {
                EasyCard.Logger.LogWarning("The Sound \"" + soundName + "\" was no found.");
            }
            return null;
        }

        public CardData[] cardStingsToList(List<string> cardStrings)
        {

            // Check the String List //
            if (cardStrings == null) return null;

            // Create the List //
            List<CardData> cardDataList = new List<CardData>();

            // Itinerate the Strings List //
            foreach (string cardString in cardStrings)
            {
                // Get the Card //
                CardData cardData = null;
                if (Globals.Instance._CardsSource.ContainsKey(cardString))
                    cardData = Globals.Instance._CardsSource[cardString];
                // Check the Card and add it to the List //
                if (cardData != null)
                    cardDataList.Add(cardData);
            }

            // Return the List //
            return cardDataList.ToArray();

        }

    }
}
