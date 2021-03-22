using UnityEngine;

public enum ItemType { NPC, HEALTH, DOOR, LASER };
public enum ItemSubType { NPC_SayThanks, NPC_ThanksAndGift, NPC_ThanksAndLvl, NPC_ThanksGiftAndLvl, HEALTH_Small, HEALTH_Medium, HEALTH_Large,HEALTH_Coffee, DOOR_KeyCard, LASER_Keys};

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item") ]
public class ItemSO : ScriptableObject
{
    //new public string name = "New Item";
    public string itemName = "New Item";
    public ItemType itemType;
    public ItemSubType itemSubType;
    public string itemFor = "NPC name";
    public string itemFrom = "NPC name";
    public int healthIncrease = 0;
    public Sprite inventoryIcon = null;
    public Sprite inventorySelectedIcon = null;
    public string recieveMessage = "You just recieved the ";
    public string itemThanks = "";
    public string itemInReturn = "";

}
