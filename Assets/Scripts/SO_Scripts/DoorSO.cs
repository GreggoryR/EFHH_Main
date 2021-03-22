using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Door SO", fileName ="Door SO")]
public class DoorSO : ScriptableObject
{
    [SerializeField] enum DoorType { RegularDoor, TopHallway, BishopBedroom};

    [SerializeField] DoorType doorType;
    [SerializeField] bool needsKey;
    
}
