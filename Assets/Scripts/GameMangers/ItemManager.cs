///////////////////////////////////////////////////////////////////////////
//FileName: ItemManager.cs
//Author : Greggory Reed
//Description : Items are connected to story moments
//              Give items to NPCs, Recieve items
//              Sometimes dialogue is triggered
//              Sometimes level is completed
///////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using UnityEngine;



public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    [SerializeField] ItemSO bishopKeyCardGift;
    [SerializeField] ItemSO barryWheelGift;
    [SerializeField] ItemSO zhaoBeerGift;
    [SerializeField] ItemSO samMatchesGift;
    [SerializeField] ItemSO oliverOxygenGift;
    [SerializeField] ItemSO ayakoTelescopeGift;
    [SerializeField] ItemSO kwanFlowerItem;
    [SerializeField] ItemSO joseRopeItem;
    [SerializeField] ItemSO ayakoNoteItem;

    enum Characters { Bishop, Barry, Zhao, Sam, Oliver, Kwan, Jose, Ayako, Afua }
    List<string> residentItemKeys = new List<string> { "BishopKey", "BarryWheel", "ZhaoBeer", "SamMatches", "OliverOxygen", "AyakoTelescope", "KwanRose", "JoseRope", "AyakoNote" };
    public Dictionary<string, ItemSO> residentItemCollection = new Dictionary<string, ItemSO>(9);
    public bool itemReturnedToPlayer;

    public delegate void TopHallwayDoorUnlockedEvent();
    public static TopHallwayDoorUnlockedEvent topHallwayDoorUnlocked;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GenerateResidentItemCollection();
    }
    #region Story Item Management
    public void ReturnItem(ItemSO item)
    {
        if (GameManager.instance.nextToNPC && item.itemFor.Equals(GameManager.instance.currentNPC.characterName))
        {
            GameManager.instance.canMove = false;
            GameManager.instance.isTalking = true;
            if (GameManager.instance.beingChased)
            {
                GameManager.instance.StopChasing();
            }
            Debug.Log("Giving the item to " + item.itemFor);
            Inventory.instance.Remove(item);
            switch (item.itemSubType)
            {
                case ItemSubType.NPC_SayThanks:
                    TalkToAfuaStoryMoment(GameManager.instance.currentNPC, item);
                    break;
                case ItemSubType.NPC_ThanksAndGift:
                    ExchageItemsAndSayThanks(GameManager.instance.currentNPC, item);
                    break;
                case ItemSubType.NPC_ThanksAndLvl:
                    NoItemToPlayerandLoadNextLevel(GameManager.instance.currentNPC);
                    break;
                case ItemSubType.NPC_ThanksGiftAndLvl:
                    GiveItemToPlayerAndLoadNextLevel(GameManager.instance.currentNPC, item);
                    break;
                case ItemSubType.NPC_AfuaSaysThanks:
                    TalkToAfuaStoryMoment(GameManager.instance.currentNPC, item);
                    break;
                case ItemSubType.HEALTH_Small:
                    Debug.LogError("Item has wrong type/subtype");
                    break;
                case ItemSubType.HEALTH_Medium:
                    Debug.LogError("Item has wrong type/subtype");
                    break;
                case ItemSubType.HEALTH_Large:
                    Debug.LogError("Item has wrong type/subtype");
                    break;
                case ItemSubType.DOOR_KeyCard:
                    Debug.LogError("Item has wrong type/subtype");
                    break;
                default:
                    break;
            }
        }
    }
    //----Initialization----//
    private void GenerateResidentItemCollection()
    {
        List<ItemSO> itemsCollection = new List<ItemSO> { bishopKeyCardGift, barryWheelGift, zhaoBeerGift, samMatchesGift, oliverOxygenGift, ayakoTelescopeGift, kwanFlowerItem, joseRopeItem, ayakoNoteItem };
        for (int i = 0; i < itemsCollection.Count; i++)
        {
            residentItemCollection.Add(residentItemKeys[i], itemsCollection[i]);
        }
    }
    //----Methods----//
    private void TalkToAfuaStoryMoment(NPCInformationSO npc, ItemSO item)
    {
        Characters character = (Characters)Enum.Parse(typeof(Characters), item.itemFor);
        GameManager.instance.chapterWithSections[GameManager.instance.chapter][(int)character]++;
        string[] characterThanks = npc.itemThanks[0].thanks;
        StoryManager.instance.canLoadNextLevel = false;
        itemReturnedToPlayer = false;
        GameManager.instance.talkedToAfua = true;
        ResidentAcceptsItem(item.itemFor, characterThanks, false);
    }
    private void ExchageItemsAndSayThanks(NPCInformationSO npc, ItemSO item)
    {
        Characters character = (Characters)Enum.Parse(typeof(Characters), item.itemFor);
        GameManager.instance.chapterWithSections[GameManager.instance.chapter][(int)character]++;
        string[] characterThanks = npc.itemThanks[0].thanks;
        StoryManager.instance.canLoadNextLevel = false;
        itemReturnedToPlayer = true;
        residentItemCollection.TryGetValue(item.itemInReturn, out ItemSO barryReturn);
        ResidentGivesItem(barryReturn, characterThanks, false);
    }
    private void NoItemToPlayerandLoadNextLevel(NPCInformationSO npc)
    {
        StoryManager.instance.canLoadNextLevel = true;
        itemReturnedToPlayer = false;
        DialogueManager.instance.ui_Inventory.SetActive(false);
        string[] bishopThanks = npc.itemThanks[GameManager.instance.chapter].thanks;
        string what = bishopThanks[0];
        DialogueManager.instance.ui_Player.SetActive(true);
        DialogueManager.instance.StartCoversation(bishopThanks, "Bishop", true);
    }
    private void GiveItemToPlayerAndLoadNextLevel(NPCInformationSO npc, ItemSO item)
    {
        StoryManager.instance.canLoadNextLevel = true;
        itemReturnedToPlayer = true;
        string[] bishopThanks = npc.itemThanks[GameManager.instance.chapter].thanks;
        string what = bishopThanks[0];
        residentItemCollection.TryGetValue(item.itemInReturn, out ItemSO bishopReturn);
        ResidentGivesItem(bishopReturn, bishopThanks, true);
    }
    //---Helper Methods----//

    public void ResidentGivesItem(ItemSO item, string[] dialogue, bool nextChapter)
    {
        switch (item.itemFrom)
        {
            
            case "Kwan":
                GameManager.instance.chapterWithSections[GameManager.instance.chapter][(int)Characters.Kwan]++;
                DontLoadLevelAndGiveItem(item, dialogue, nextChapter);
            break;
            case "Jose":
                GameManager.instance.chapterWithSections[GameManager.instance.chapter][(int)Characters.Jose]++;
                DontLoadLevelAndGiveItem(item, dialogue, nextChapter);
            break;
            case "Ayako":
                Characters ayako = (Characters)Enum.Parse(typeof(Characters), item.itemFor);
                GameManager.instance.chapterWithSections[GameManager.instance.chapter][(int)Characters.Ayako]++;
                DontLoadLevelAndGiveItem(item, dialogue, nextChapter);
            break;
            case "AyakoTelescope":
                Characters ayakoTele = (Characters)Enum.Parse(typeof(Characters), item.itemFor);
                GameManager.instance.chapterWithSections[GameManager.instance.chapter][(int)Characters.Ayako]++;
                DontLoadLevelAndGiveItem(item, dialogue, nextChapter);
            break;
            default:
            ResidentGivesGiftAndSaysDialogue(item.itemFrom, dialogue, item, nextChapter);
            break;
        }
    } 
    private void DontLoadLevelAndGiveItem(ItemSO item, string[] dialogue, bool nextChapter)
    {
        StoryManager.instance.canLoadNextLevel = false;
        itemReturnedToPlayer = true;
        ResidentGivesGiftAndSaysDialogue(item.itemFrom, dialogue, item, nextChapter);
    }
    private void ResidentGivesGiftAndSaysDialogue(string characterName, string[] dialogue, ItemSO returnedItem, bool nextChapter) //resident gives gift
    {
        DialogueManager.instance.ui_Inventory.SetActive(false);
        Inventory.instance.AddItem(returnedItem);
        DialogueManager.instance.StartGiftCoversation(dialogue, characterName, returnedItem.recieveMessage, nextChapter);
        DialogueManager.instance.ui_Player.SetActive(true);
        Debug.Log("Recieved gift from " + characterName);
    }
    private void ResidentAcceptsItem(string characterName, string[] dialogue, bool nextChapter) //resident recieves gift
    {
        DialogueManager.instance.ui_Inventory.SetActive(false);
        DialogueManager.instance.StartCoversation(dialogue, characterName, nextChapter);
        DialogueManager.instance.ui_Player.SetActive(true);
    }

    //old methods
    public void ReturnItemToResident(NPCInformationSO npc, ItemSO item)
    {
        switch (item.itemFor)
        {
            case "Barry":
                ExchageItemsAndSayThanks(npc, item);
                break;
            case "Zhao":
                ExchageItemsAndSayThanks(npc, item);
                break;
            case "Sam":
                ExchageItemsAndSayThanks(npc, item);
                break;
            case "Oliver":
                ExchageItemsAndSayThanks(npc, item);
                break;
            case "Afua":
                TalkToAfuaStoryMoment(npc, item);
                break;
            default:
                break;
        }
    }
    public void NextChapterItemReturn(NPCInformationSO npc, ItemSO item)
    {
        switch (item.itemName)
        {
            case "Wheel":
                NoItemToPlayerandLoadNextLevel(npc);
                break;
            case "OxygenTank":
                NoItemToPlayerandLoadNextLevel(npc);
                break;
            case "Rope":
                NoItemToPlayerandLoadNextLevel(npc);
                break;
            case "Telescope":
                NoItemToPlayerandLoadNextLevel(npc);
                break;
            default:
                break;
        }
    }
    #endregion
    #region Health Item Management
    public void UseHealthItem(ItemSO item)
    {
        if(GameManager.instance.playerHealth < GameManager.instance.playerMaxHealth)
        {
            int health = GameManager.instance.playerHealth;
            int valueHealth = Mathf.Clamp(health += item.healthIncrease, 0, 5);
            GameManager.instance.playerHealth = valueHealth;
            HealthUIBroker.HealthIsGainedCall();
            Debug.Log("Health increased by " + item.healthIncrease + " -- Health is now " + GameManager.instance.playerHealth);
            Inventory.instance.Remove(item);
        }
        //if not, don't use
        //send notification
    }
    #endregion
    #region Key Items Management

    public void TryToOpenDoorWithKey(MessageSO message, ItemSO item)
    {
        if (GameManager.instance.currentDoor != null)
        {
            GameManager.instance.canMove = false;
            GameManager.instance.isTalking = true;
            GameManager.instance.StopChasing();
            Debug.Log("Unlocking door");
            Inventory.instance.Remove(item);
            GameManager.instance.currentDoor.GetComponent<DoorManager>().doorLocked = DoorManager.DoorLocked.unlocked;
            if(item.itemSubType == ItemSubType.DOOR_KeyCard && topHallwayDoorUnlocked != null)
            {
                topHallwayDoorUnlocked.Invoke();
            }
            DialogueManager.instance.ui_Inventory.SetActive(false);
            NotificationBroker.DoorIsLockedCall(message);
        }
    }
    #endregion
}



//        if (item.itemType.)
//        {
//            //check if talking to character
//            if (GameManager.instance.nextToNPC && item.itemFor.Equals(GameManager.instance.currentNPC.characterName)) +
//            {
//                ItemSO item = this.item; +
//                GameManager.instance.isTalking = true;
//                GameManager.instance.StopChasing();
//                Debug.Log("Giving the item to " + item.itemFor);
//                Inventory.instance.Remove(this.item);
//                ItemManager.instance.ReturnItemToResident(GameManager.instance.currentNPC, item);


//            }
//            else if (!GameManager.instance.currentDoor)
//            {
//                //remove item from inventory if key is meant for the door
//                //open the door with an animation
//            }
//            return;
//        }
//        if (item.type.Equals("EndOfChapter"))
//        {
//            if (GameManager.instance.nextToNPC && item.itemFor.Equals(GameManager.instance.currentNPC.characterName))
//            {
//                ItemSO item = this.item;
//                GameManager.instance.isTalking = true;
//                GameManager.instance.StopChasing();
//                Debug.Log("Giving the item to " + item.itemFor);
//                Inventory.instance.Remove(this.item);
//                ItemManager.instance.NextChapterItemReturn(GameManager.instance.currentNPC, item);

//            }
//            return;
//        }
