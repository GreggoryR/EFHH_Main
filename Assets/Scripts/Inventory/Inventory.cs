///////////////////////////////////////////////////////////////////////////
//FileName: Inventory.cs
//Author : Greggory Reed
//Description : Class for player inventory
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    [SerializeField] UI_Inventory uI_Inventory;

    public delegate void OnItemChanged();
    public event OnItemChanged OnItemChangedCallback; // delegate/events need to have uppercase

    public bool hasAdded = false;
    public bool itemSelected = false;
    public int selectedItemSlotNum;
    public ItemSO selectedItem;



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
    public void Start()
    {
        if(GameManager.instance.chapter > 0)
        {
            hasAdded = true;
        }
        selectedItemSlotNum = -1;
    }
    public bool AddItem(ItemSO item)
    {
        if(GameManager.instance.itemList.Count >= GameManager.instance.space)
        {
            Debug.Log("not enough room");
            return false;
        }
        GameManager.instance.itemList.Add(item);
        hasAdded = true;
        if (OnItemChangedCallback != null) //check if method is subscribed
        {
            OnItemChangedCallback.Invoke();
        }
        return true;
    }

    
    public void Remove(ItemSO item)
    {
        GameManager.instance.itemList.Remove(item);
        selectedItem = null;
        //if (GameManager.instance.itemList.Count == 0) //forget why this matters
        //{
        //    hasAdded = false;
        //}
        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }

    public int ReturnSelectedSlot()
    {
        return this.selectedItemSlotNum;
    }
}
