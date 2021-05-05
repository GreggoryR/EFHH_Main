///////////////////////////////////////////////////////////////////////////
//FileName: EnemyController.cs
//Author : Greggory Reed
//Description : Class for moving enemy with A*Pathfinding Project and more
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using UnityEngine.SceneManagement;

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
    [SerializeField] float distanceTop;
    [SerializeField] float distanceBottom;
    public float[] playerPaths = new float[4];
    public bool pivoting = false;
    public int health = 2;
    public bool canAttack = true;
    public bool isDead;
    [Space]

    [Header("Waypoint Information")]
    public List<Waypoint> individualRoute;
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
    public float directionX = 0; //less than right, more than left
    public float directionY = 0; //less than up, more than down
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

    private void Start()
    {
        currentWaypoint = 0;
        if(SceneManager.GetActiveScene().buildIndex < 8)
        {
            GetWaypointRoute();
            SetFirstWaypointAsTarget();
        }
        
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

        if (!animator.GetBool("FaceRight") && !animator.GetBool("FaceLeft") && !animator.GetBool("FaceUp") && !animator.GetBool("FaceDown"))
        {
            animator.SetBool("FaceDown", true);
        }
        if (pivoting)
        {
            CalculateEnemyPivot();
            pivoting = false;
        }
        else
        {

            CalculateEnemyMovement();
        }
        animator.SetFloat("Horizontal", xValue);
        animator.SetFloat("Vertical", yValue);
        animator.SetFloat("Magnitude", enemyMagnitude);

    }



    private void CalculateEnemyMovement()
    {
        if (aiDestinationSetter.target)
        {
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
                animator.SetBool("NoInput", false);
                animator.SetBool("FaceRight", true);
                animator.SetBool("FaceLeft", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", false);
            }
            else if (offsetX > 0)
            {
                xValue = -1;
                animator.SetBool("NoInput", false);
                animator.SetBool("FaceLeft", true);
                animator.SetBool("FaceRight", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", false);
            }

            if (offsetY > -.9 && offsetY < .9)
            {
                yValue = 0;
                if (xValue == 0)
                {
                    animator.SetBool("NoInput", true);
                }
            }
            else if (offsetY < 0)
            {
                yValue = 1;
                if (xValue == 0)
                {
                    animator.SetBool("NoInput", false);
                    animator.SetBool("FaceLeft", false);
                    animator.SetBool("FaceRight", false);
                    animator.SetBool("FaceUp", true);
                    animator.SetBool("FaceDown", false);
                }
            }
            else if (offsetY > 0)
            {
                yValue = -1;
                if (xValue == 0)
                {
                    animator.SetBool("NoInput", false);
                    animator.SetBool("FaceLeft", false);
                    animator.SetBool("FaceRight", false);
                    animator.SetBool("FaceUp", false);
                    animator.SetBool("FaceDown", true);
                }
            }
            else
            {
                yValue = 0;
            }

            enemyMagnitude = transform.position.magnitude;
            animator.SetFloat("Magnitude", enemyMagnitude);
        }
        
    }

    public void CalculateEnemyPivot()
    {
        enemyMagnitude = 0f;
        animator.SetFloat("Magnitude", enemyMagnitude);
    }

    public void PauseWalking()
    {
        StartCoroutine(PauseWalkingRoutine());
    }

    IEnumerator PauseWalkingRoutine()
    {
        steeringTarget.canMove = false;
        yield return new WaitForSeconds(2f);
        steeringTarget.canMove = true;
    }

    public void Attack(Position playerPos)
    {

        switch (playerPos)
        {
            case Position.North:
                animator.SetBool("IsPunching", true);

                animator.SetBool("FaceLeft", false);
                animator.SetBool("FaceRight", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", false);
                animator.SetBool("FaceDown", true);
                break;
            case Position.South:
                animator.SetBool("IsPunching", true);
                animator.SetBool("FaceLeft", false);
                animator.SetBool("FaceRight", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", false);
                animator.SetBool("FaceUp", true);
                break;
            case Position.East:
                animator.SetBool("IsPunching", true);
                animator.SetBool("FaceLeft", false);
                animator.SetBool("FaceRight", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", false);
                animator.SetBool("FaceLeft", true);
                break;
            case Position.West:
                animator.SetBool("IsPunching", true);
                animator.SetBool("FaceLeft", false);
                animator.SetBool("FaceRight", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", false);
                animator.SetBool("FaceRight", true);
                break;
            default:
                break;
        }
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
        if (aiDestinationSetter.target)
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
            playerPaths[0] = distanceRight;
            distanceLeft = Vector2.Distance(this.transform.position, playerDestinations[1].transform.position);
            playerPaths[1] = distanceLeft;
            distanceTop = Vector2.Distance(this.transform.position, playerDestinations[2].transform.position);
            playerPaths[2] = distanceTop;
            distanceBottom = Vector2.Distance(this.transform.position, playerDestinations[3].transform.position);
            playerPaths[3] = distanceBottom;
            float smallestValue = 0;
            int positionIndex = 0;
            for(int i = 0; i < 4; i++)
            {
                if(i == 0)
                {
                    smallestValue = playerPaths[i];
                    positionIndex = i;
                }
                else if (playerPaths[i] < smallestValue)
                {
                    smallestValue = playerPaths[i];
                    positionIndex = i;
                }
            }

            switch (positionIndex)
            {
                case 0:
                    aiDestinationSetter.target = playerDestinations[0].transform;
                    break;
                case 1:
                    aiDestinationSetter.target = playerDestinations[1].transform;
                    break;
                case 2:
                    aiDestinationSetter.target = playerDestinations[2].transform;
                    break;
                case 3:
                    aiDestinationSetter.target = playerDestinations[3].transform;
                    break;
                default:
                    break;
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



