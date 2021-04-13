///////////////////////////////////////////////////////////////////////////
//FileName: SelectedSlotSlot.cs
//Author : Greggory Reed
//Description : Class for selected slot
////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;



public class SelectedSlot : MonoBehaviour
{
    ItemSO item;
    public Image icon;
    public MessageSO unlocked;

    

    public void AddItem(ItemSO newItem)
    {
        item = newItem;

        icon.enabled = true;
        icon.sprite = item.inventorySelectedIcon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem() //is a button
    {
        switch (item.itemType)
        {
            case ItemType.NPC:
                NotificationBroker.TurnOffButtonsCall();
                ItemManager.instance.ReturnItem(item);
                break;
            case ItemType.HEALTH:
                ItemManager.instance.UseHealthItem(item);
                break;
            case ItemType.DOOR:
                ItemManager.instance.TryToOpenDoorWithKey(unlocked, item);
                break;
            default:
                break;
        }
    }

    
}

