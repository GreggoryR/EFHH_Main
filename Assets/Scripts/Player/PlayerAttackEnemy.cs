///////////////////////////////////////////////////////////////////////////
//FileName: PlayerAttackEnemy.cs
//Author : Greggory Reed
//Description : Class to attack the enemy
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerAttackEnemy : MonoBehaviour
{
    Vector2 parentObjectPos;
    void Start()
    {
        parentObjectPos = GetComponentInParent<BasicMovement>().gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyReceiveAttack"))
        {
            collision.GetComponentInParent<EnemyController>().canGetStunned = true;
            collision.GetComponentInParent<EnemyController>().playerPos = parentObjectPos;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyReceiveAttack"))
        {
            collision.GetComponentInParent<EnemyController>().canGetStunned = false;
        }
    }
}
