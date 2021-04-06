///////////////////////////////////////////////////////////////////////////
//FileName: DoorManager.cs
//Author : Greggory Reed
//Description : Will handle unlocking and opening doors based on the level
////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DoorManager : MonoBehaviour
{
    [SerializeField] GameObject playerButtonCanvas;

    [SerializeField] Material[] doorRadarColors;
    [SerializeField] GameObject doorRadar;
    BoxCollider2D doorCollider;
    [SerializeField] bool doorIsLocked = false;
    public bool playerIsNextToDoor = false;
    enum DoorType { topHallway, entrance, garden, bedroom, ayako, elevator };
    [SerializeField] DoorType doorType;
    enum DoorLocked {locked, unlocked};
    [SerializeField] DoorLocked doorLocked;

    [SerializeField] GameObject doorLight;

    //Top Hallway Transition
    [SerializeField] GameObject topHallwayRoof;
    [SerializeField] GameObject topHallwayRadar;

    [SerializeField] MessageSO doorIsLockedMessage;

    public void Start()
    {
        switch (doorLocked)
        {
            case DoorLocked.locked:
                doorRadar.GetComponent<SpriteRenderer>().material = doorRadarColors[0];
                break;
            case DoorLocked.unlocked:
                doorRadar.GetComponent<SpriteRenderer>().material = doorRadarColors[1];
                break;
            default:
                break;
        }
        doorCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (playerIsNextToDoor && Input.GetKeyDown(KeyCode.E))
        {
            TryToOpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsNextToDoor = true;
            if (!doorIsLocked)
            {
                playerButtonCanvas.SetActive(true);
            }
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsNextToDoor = false;
            if (!doorIsLocked)
            {
                playerButtonCanvas.SetActive(false);
            }
        }
    }
    private void TryToOpenDoor()
    {
        if (doorCollider)
        {
            switch (doorType)
            {
                case DoorType.topHallway:
                    switch (doorLocked)
                    {
                        case DoorLocked.locked:
                            NotificationBroker.DoorIsLockedCall(doorIsLockedMessage);
                            break;
                        case DoorLocked.unlocked:
                            doorCollider.enabled = false;
                            topHallwayRoof.SetActive(false);
                            topHallwayRadar.SetActive(true);
                            playerButtonCanvas.SetActive(false);
                            break;
                        default:
                            break;
                    }
                    break;
                case DoorType.entrance:
                    playerButtonCanvas.SetActive(false);
                    break;
                case DoorType.garden:
                    switch (doorLocked)
                    {
                        case DoorLocked.locked:
                            NotificationBroker.DoorIsLockedCall(new MessageSO { message = "Door is locked" });
                            break;
                        case DoorLocked.unlocked:
                            doorCollider.enabled = false;
                            playerButtonCanvas.SetActive(false);
                            doorLight.SetActive(true);
                            break;
                        default:
                            break;
                    }
                    break;
                    break;
                case DoorType.bedroom:
                    switch (doorLocked)
                    {
                        case DoorLocked.locked:
                            NotificationBroker.DoorIsLockedCall(new MessageSO { message = "Door is locked" });
                            break;
                        case DoorLocked.unlocked:
                            doorCollider.enabled = false;
                            playerButtonCanvas.SetActive(false);
                            doorLight.SetActive(true);
                            break;
                        default:
                            break;
                    }
                    break;
                case DoorType.ayako:
                    playerButtonCanvas.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        //move collider for the animation?
        //play animation
        //on animaton exit, destroy collider
    }
}
