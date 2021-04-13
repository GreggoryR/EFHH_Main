//////////////////////////////////////////////////////////////
//FileName: HallwayManager.cs
//Author : Greggory Reed
//Description : For activating hallways after unlocking a door and more
////////////////////////////////////////////////////////////////////////////
///
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    [SerializeField] GameObject lights;
    [SerializeField] GameObject radar;
    [SerializeField] GameObject topObjects;
    [SerializeField] GameObject doorChange;
    void Start()
    {
        ItemManager.topHallwayDoorUnlocked += ActivateTopHallway;
    }

    void Update()
    {
        
    }

    public void ActivateTopHallway()
    {
        lights.SetActive(true);
        radar.SetActive(true);
        doorChange.GetComponent<DoorManager>().UpdateDoor();
    }

    private void OnDestroy()
    {
        ItemManager.topHallwayDoorUnlocked -= ActivateTopHallway;
    }
}
