///////////////////////////////////////////////////////////////////////
//FileName: Waypoint.cs
//Author : Greggory Reed
//Description : Class for waypoint to detect when enemy has entered
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWaypointNotify"))
        {
            collision.gameObject.GetComponentInParent<EnemyController>().SetNextWaypointAsTarget();
        }
    }
}
