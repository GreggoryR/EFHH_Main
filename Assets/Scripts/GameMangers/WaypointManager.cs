using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager instance;
    [SerializeField] List<GameObject> allRoutes;
    public List<List<Waypoint>> allRoutesToGive = new List<List<Waypoint>>();
    int routesGiven;
    public bool canCreatePath;
    

    private void Awake()
    {
        allRoutesToGive = new List<List<Waypoint>>();
        if (instance == null)
        {
            instance = this;
        }
        foreach (var route in allRoutes)
        {
            allRoutesToGive.Add(route.GetComponent<AIWaypointList>().ReturnListOfWayPoints());
        }
        routesGiven = -1;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public List<Waypoint> ReturnEnemyRoute()
    {
        routesGiven++;
        if (routesGiven < allRoutesToGive.Count)
        {
            return allRoutesToGive[routesGiven];
        }
        else
        {
            routesGiven = -1;
            return ReturnEnemyRoute();
        }
        
    }


}
