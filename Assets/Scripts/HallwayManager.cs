using System.Collections;
using System.Collections.Generic;
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
