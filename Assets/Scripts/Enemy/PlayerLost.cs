///////////////////////////////////////////////////////////////////////
//FileName: PlayerLost.cs
//Author : Greggory Reed
//Description : Class for detecting when enemy loses the player
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerLost : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject playerFound;
    [SerializeField] GameObject enemyAttack;
    [SerializeField] GameObject getStunned;
    [SerializeField] GameObject radarColor;

    [Header("ChaseCinematics")]
    [SerializeField] GameObject ui_chase_canvas;
    [SerializeField] Animator ui_image_animator;
    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] GameObject parentEnemy;
    [SerializeField] GameObject radar;
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.beingChased = false;
            playerFound.SetActive(true);
            enemyAttack.SetActive(false);
            getStunned.SetActive(false);
            radarColor.GetComponent<SpriteRenderer>().color = Color.green;
            gameObject.GetComponentInParent<EnemyController>().SetNextWaypointAsTarget();
            radar.SetActive(true);
            playerAudioSource.Stop();
            ui_chase_canvas.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
