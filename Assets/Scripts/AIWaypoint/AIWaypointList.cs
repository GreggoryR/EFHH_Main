using System.Collections;
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
