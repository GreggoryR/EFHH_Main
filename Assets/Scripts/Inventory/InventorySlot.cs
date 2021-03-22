using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    ItemSO item;
    public Image icon;
    public Sprite blankIcon;
    public int slotID = 0;

    public delegate void OnItemSelected();
    public OnItemSelected OnItemSelectedCallback;

    public void AddItem(ItemSO newItem)
    {
        item = newItem;
        icon.sprite = item.inventoryIcon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = blankIcon;
        icon.enabled = false;
    }

    public void SelectAnItem()
    {
        if(item != null && OnItemSelectedCallback != null)
        {
            int selectedItemSlotNum = Inventory.instance.ReturnSelectedSlot();
            if (slotID == selectedItemSlotNum && Inventory.instance.selectedItem)
            {
                Inventory.instance.selectedItem = null;
                OnItemSelectedCallback.Invoke();
            }
            else if (slotID == selectedItemSlotNum && !Inventory.instance.selectedItem)
            {
                Inventory.instance.selectedItem = item;
                OnItemSelectedCallback.Invoke();
            }
            else
            {
                Inventory.instance.selectedItemSlotNum = slotID;
                Inventory.instance.selectedItem = item;
                OnItemSelectedCallback.Invoke();
            }
        }
    }

}
