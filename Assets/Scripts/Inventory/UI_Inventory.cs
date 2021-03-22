using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{

    //public static UI_Inventory instance;
    public Transform itemsParent;
    public Transform selectedSlotParent;
    
    SelectedSlot selectedSlot;

    //private void Awake() // not sure right now
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        //inventory =  GameManager.instance.inventory;
        Inventory.instance.OnItemChangedCallback += UpdateItemsUI; //subscribing here
        Inventory.instance.OnItemChangedCallback += UpdateSelectedItemUI; //subscribing here
        GameManager.instance.slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        selectedSlot = selectedSlotParent.GetComponent<SelectedSlot>();
        foreach (var item in GameManager.instance.slots)
        {
            item.OnItemSelectedCallback += UpdateSelectedItemUI;
        }
        InitializeSlots();
        UpdateItemsUI();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeSlots()
    {
        for (int i = 0; i < GameManager.instance.slots.Length; i++)
        {
            GameManager.instance.slots[i].slotID = i;
        }
            
    }

    void UpdateItemsUI()
    {
        for (int i = 0; i < GameManager.instance.slots.Length; i++)
        {
            if(i < GameManager.instance.itemList.Count)
            {

                GameManager.instance.slots[i].AddItem(GameManager.instance.itemList[i]);
            }
            else
            {
                GameManager.instance.slots[i].ClearSlot();
            }
        }
    }

    void UpdateSelectedItemUI()
    {
        if (Inventory.instance.hasAdded && Inventory.instance.selectedItem)
        {
            selectedSlot.AddItem(Inventory.instance.selectedItem);
        }
        else if (Inventory.instance.hasAdded && !Inventory.instance.selectedItem) //might need to remove has added later
        {
            selectedSlot.ClearSlot();
        }
    }

}
