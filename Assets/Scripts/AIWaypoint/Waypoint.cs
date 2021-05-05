///////////////////////////////////////////////////////////////////////
//FileName: Waypoint.cs
//Author : Greggory Reed
//Description : Class for waypoint to detect when enemy has entered
////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public enum Position { North, South, East, West };
public class Waypoint : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWaypointNotify"))
        {
            collision.gameObject.GetComponentInParent<EnemyController>().pivoting = true;
            if(SceneManager.GetActiveScene().buildIndex < 8)
            {
                collision.gameObject.GetComponentInParent<EnemyController>().SetNextWaypointAsTarget();
            }
            
        }
    }
}
