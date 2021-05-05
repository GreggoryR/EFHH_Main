///////////////////////////////////////////////////////////////////////////
//FileName: PlayerAIDestination.cs
//Author : Greggory Reed
//Description : Filler class for transform
////////////////////////////////////////////////////////////////////////////
using System.Collections;
using UnityEngine;

public class PlayerAIDestination : MonoBehaviour
{
    
    [SerializeField] public Position waypointPos;
    public bool atPlayerPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWaypointNotify"))
        {
            atPlayerPos = true;
            if (!collision.GetComponentInParent<EnemyController>().isDead)
            {
                StartCoroutine(AttackFromPos(collision));
            }
            
        }
    }

    public IEnumerator AttackFromPos(Collider2D collision)
    {
        bool canTry;
        while (atPlayerPos)
        {
            try
            {
                collision.gameObject.GetComponentInParent<EnemyController>().PauseWalking();
                canTry = true;
            }
            catch (System.Exception)
            {
                canTry = false;
                atPlayerPos = false;
                StopCoroutine(AttackFromPos(collision));
            }

            if (canTry)
            {
                try
                {
                    collision.gameObject.GetComponentInParent<EnemyController>().PauseWalking();
                }
                catch (System.Exception)
                {
                    canTry = false;
                    atPlayerPos = false;
                    StopCoroutine(AttackFromPos(collision));
                }
                yield return new WaitForSeconds(1f);

                try
                {
                    if (collision.gameObject.GetComponentInParent<EnemyController>().canAttack)
                    {
                        collision.gameObject.GetComponentInParent<EnemyController>().Attack(waypointPos);
                    }
                }
                catch (System.Exception)
                {
                    canTry = false;
                    atPlayerPos = false;
                    StopCoroutine(AttackFromPos(collision));
                }
                
                yield return new WaitForSeconds(1f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWaypointNotify"))
        {
            atPlayerPos = false;
        }
    }
}
