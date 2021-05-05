///////////////////////////////////////////////////////////////////////////
//FileName: ItemPickup.cs
//Author : Greggory Reed
//Description : Class for picking up items
////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemSO itemSO;
    bool canPickUP = false;
    //SpriteRenderer colorRenderer;
    [SerializeField] GameObject playerButtonCanvas;
    [SerializeField] Animator playerAnimator;

    private void Awake()
    {
        //colorRenderer = transform.GetComponentInChildren<SpriteRenderer>();
    }
    public void Update()
    {
        if (canPickUP && Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetBool("GrabDown", true);
            GameManager.instance.canMove = false;
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
            playerButtonCanvas.SetActive(false);
            Destroy(gameObject);
            NotificationBroker.ItemRecievedFromDeskCall(itemSO.recieveMessageGround);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerFoundCollider") && canPickUP == false)
        {
            playerButtonCanvas.SetActive(true);
            canPickUP = true;
            //colorRenderer.color = Color.green;
            
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerButtonCanvas.SetActive(false);
        //colorRenderer.color = Color.white;
        canPickUP = false;

    }


}
