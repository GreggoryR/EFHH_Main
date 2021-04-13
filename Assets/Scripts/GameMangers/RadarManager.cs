///////////////////////////////////////////////////////////////////////////
//FileName: RadarManager.cs
//Author : Greggory Reed
//Description : Class for radar
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class RadarManager : MonoBehaviour
{
    [SerializeField] Camera radarCam;

    //the top hallway transition
    void Start()
    {
        EnterExitBroker.PlayerEntersBuilding += ChangeRaderMaskEnter;
        EnterExitBroker.PlayerExitsBuilding += ChangeRaderMaskExit;
    }

    private void OnDestroy()
    {
        EnterExitBroker.PlayerEntersBuilding -= ChangeRaderMaskEnter;
        EnterExitBroker.PlayerExitsBuilding -= ChangeRaderMaskExit;
    }

    private void ChangeRaderMaskEnter()
    {
        radarCam.cullingMask = LayerMask.GetMask("Radar");
    }

    private void ChangeRaderMaskExit()
    {
        radarCam.cullingMask = LayerMask.GetMask("RadarOutside");
    }
}
