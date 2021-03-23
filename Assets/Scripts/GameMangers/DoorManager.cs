///////////////////////////////////////////////////////////////////////////
//FileName: DoorManager.cs
//Author : Greggory Reed
//Description : Will handle unlocking and opening doors based on the level
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] Material[] doorRadarColors;
    [SerializeField] GameObject doorRadar;
    BoxCollider2D doorCollider;
    [SerializeField] bool doorIsLocked = false;
    public bool playerIsNextToDoor = false;
    enum DoorType { topHallway, entrance, garden, bedroom, ayako, elevator };
    [SerializeField] DoorType doorType;
    enum DoorLocked {locked, unlocked};
    [SerializeField] DoorLocked doorLocked;

    //Top Hallway Transition
    [SerializeField] GameObject topHallwayRoof;
    [SerializeField] GameObject topHallwayRadar;


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
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsNextToDoor = false;
        }
    }
    private void TryToOpenDoor()
    {
        if (doorCollider)
        {
            switch (doorType)
            {
                case DoorType.topHallway:
                    doorCollider.enabled = false;
                    topHallwayRoof.SetActive(false);
                    topHallwayRadar.SetActive(true);
                    break;
                case DoorType.entrance:
                    break;
                case DoorType.garden:
                    break;
                case DoorType.bedroom:
                    //implement other stuff
                    doorCollider.enabled = false;
                    break;
                case DoorType.ayako:
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
