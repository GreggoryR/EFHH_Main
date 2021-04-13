///////////////////////////////////////////////////////////////////////////
//FileName: LaserCannonManager.cs
//Author : Greggory Reed
//Description : Class for managing the laser
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class LaserCannonManager : MonoBehaviour
{
    [SerializeField] public float currentRotation;
    [SerializeField] public float wantedRotation;

    bool canFire = false; 
}
