using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemSO itemSO;
    bool canPickUP = false;
    SpriteRenderer colorRenderer;

    private void Awake()
    {
        colorRenderer = transform.GetComponentInChildren<SpriteRenderer>();
    }
    public void Update()
    {
        if (canPickUP && Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }

    }

    private void Pickup()
    {
        Debug.Log("Picking up " + itemSO.itemName);
        bool pickUpSuccessful = Inventory.instance.AddItem(itemSO);
        if (pickUpSuccessful)
        {
            SoundBroker.PlayerSoundCall(Player_Sounds.item_Pickup);
            Inventory.instance.hasAdded = true;
            Destroy(gameObject);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerFoundCollider") && canPickUP == false)
        {
            canPickUP = true;
            colorRenderer.color = Color.green;
            
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colorRenderer.color = Color.white;
        canPickUP = false;

    }


}
