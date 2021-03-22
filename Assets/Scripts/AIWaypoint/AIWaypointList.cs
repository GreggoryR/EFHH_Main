////////////////////////////////////////////////////////////
//FileName: AIWaypointList.cs
//Author : Greggory Reed
//Description : Class for generating a list of waypoints for each enemy
////////////////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;

public class AIWaypointList : MonoBehaviour
{
    [SerializeField] List<Waypoint> listOfWaypoints;

    private void Awake()
    {
        listOfWaypoints = new List<Waypoint>();
        Waypoint[] transformArray = gameObject.GetComponentsInChildren<Waypoint>();
        foreach (var item in transformArray)
        {
            listOfWaypoints.Add(item);
        }
    }
    public List<Waypoint> ReturnListOfWayPoints()
    {
        return this.listOfWaypoints;
    }
}
