using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Information")]
    [SerializeField] bool outsideEnemy;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] public bool canGetStunned = false;
    [SerializeField] public bool stunInProgress = false;
    [SerializeField] public Vector2 playerPos;
    [SerializeField] public PlayerAIDestination[] playerDestinations;
    [SerializeField] float distanceRight;
    [SerializeField] float distanceLeft;
    [Space]

    [Header("Waypoint Information")]
    private List<Waypoint> individualRoute;
    [SerializeField] public AIDestinationSetter aiDestinationSetter;
    [SerializeField] AIPath steeringTarget;
    private int currentWaypoint;
    [Space]

    public Animator animator;
    [Space]

    [Header("Waypoint Information")]
    [SerializeField] GameObject player;
    [Space]

    [Header("Movement")]
    public float directionX = 0; //less that right, more than left
    public float directionY = 0; //less that up, more than down
    public float xValue = 0;
    public float yValue = 0;
    public float steerX;
    public float steerY;
    public float offsetX;
    public float offsetY;
    public float enemyMagnitude;
    [Space]

    [Header("Radar")]
    [SerializeField] GameObject raderObject;

    private void Awake()
    {

    }
    private void Start()
    {
        currentWaypoint = 0;
        GetWaypointRoute();
        SetFirstWaypointAsTarget();
        GameManager.instance.onNotChasingAnymore += SetNextWaypointAsTarget;
        //EnterExitBroker.PlayerEntersBuilding += RadarCheckEnter; observer pattern example
        //EnterExitBroker.PlayerExitsBuilding += RadarCheckExit;
    }

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canGetStunned)
        {
            if (!stunInProgress)
            {
                stunInProgress = true;
                StartCoroutine(GetStunned());
                stunInProgress = false;
            }
        }

        steerX = aiDestinationSetter.target.transform.position.x;
        steerY = aiDestinationSetter.target.transform.position.y;
        offsetX = transform.position.x - steerX;
        offsetY = transform.position.y - steerY;



        if (offsetX > -.9 && offsetX < .9)
        {
            xValue = 0;
        }
        else if (offsetX < 0)
        {
            xValue = 1;
        }
        else if (offsetX > 0)
        {
            xValue = -1;
        }

        if (offsetY > -.9 && offsetY < .9)
        {
            yValue = 0;
        }
        else if (offsetY < 0)
        {
            yValue = 1;
        }
        else if (offsetY > 0)
        {
            yValue = -1;
        }
        else
        {
            yValue = 0;
        }

        if (offsetX < 0.5 && offsetX > -0.5 && offsetY < 0.5 && offsetY > -0.5)
        {
            enemyMagnitude = 0f;
        }
        else
        {
            enemyMagnitude = transform.position.magnitude;
        }

        animator.SetFloat("Horizontal", xValue);
        animator.SetFloat("Vertical", yValue);
        animator.SetFloat("Magnitude", enemyMagnitude);

    }

    IEnumerator GetStunned()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        Debug.Log("Is Stunned");
        yield return new WaitForSeconds(4f);
        rb.constraints = RigidbodyConstraints2D.None;
    }

    private void GetWaypointRoute()
    {
        individualRoute = WaypointManager.instance.ReturnEnemyRoute();
    }
    private void SetFirstWaypointAsTarget()
    {
        aiDestinationSetter.target = individualRoute[currentWaypoint].transform;
    }

    public void SetNextWaypointAsTarget()
    {
        if (individualRoute != null)
        {
            currentWaypoint++;
            if (currentWaypoint >= individualRoute.Count)
            {
                currentWaypoint = 0;
            }
            aiDestinationSetter.target = individualRoute[currentWaypoint].transform;
        }

    }

    public void GenerateDestination()
    {
        StartCoroutine(GenerateShortestDestination());
    }

    IEnumerator GenerateShortestDestination()
    {
        if (GameManager.instance.beingChased)
        {
            playerDestinations = FindObjectsOfType<PlayerAIDestination>();
            distanceRight = Vector2.Distance(this.transform.position, playerDestinations[0].transform.position);
            distanceLeft = Vector2.Distance(this.transform.position, playerDestinations[1].transform.position);
            if (distanceRight < distanceLeft)
            {
                aiDestinationSetter.target = playerDestinations[0].transform;
            }
            else
            {
                aiDestinationSetter.target = playerDestinations[1].transform;
            }
            yield return new WaitForSeconds(2f);
            yield return StartCoroutine(GenerateShortestDestination());
        }
    }

    //#region Radar Checking
    //private void RadarCheckEnter()
    //{
    //    if (outsideEnemy)
    //    {
    //        DisableRadar();
    //    }
    //    else
    //    {
    //        EnableRadar();
    //    }
    //}

    //private void RadarCheckExit()
    //{
    //    if (outsideEnemy)
    //    {
    //        EnableRadar();
    //    }
    //    else
    //    {
    //        DisableRadar();
    //    }
    //}

    //private void EnableRadar()
    //{
    //    raderObject.SetActive(true);
    //}

    //private void DisableRadar()
    //{
    //    raderObject.SetActive(false);
    //}
    //#endregion
}



