///////////////////////////////////////////////////////////////////////////
//FileName: PlayerAIDestination.cs
//Author : Greggory Reed
//Description : Filler class for damage
////////////////////////////////////////////////////////////////////////////
using System.Collections;
using UnityEngine;

public class PlayerReceiveDamage : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerImage;
    bool blinking = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            RemoveHealth();
        }
    }

    private void RemoveHealth()
    {
        GameManager.instance.playerHealth--;
        SoundBroker.PlayerSoundCall(Player_Sounds.punchHit);
        if (!blinking)
        {
            StartCoroutine(PlayerBlink());
        }
        HealthUIBroker.HealthIsLostCall();
        if (GameManager.instance.playerHealth == 0)
        {
            Debug.Log("Remove one health -- Health is " + GameManager.instance.playerHealth);
            GameManager.instance.canMove = false;
            GameManager.instance.canPunch = false;
            GameManager.instance.gameOver = true;
            GameManager.instance.GameOver();
            
        }
        else
        {
            Debug.Log("Remove one health -- Health is " + GameManager.instance.playerHealth);
        }
    }

    IEnumerator PlayerBlink()
    {
        Color tmp = playerImage.color;
        blinking = true;
        for (int i = 0; i < 5; i++)
        {
            tmp.a = 0.5f;
            playerImage.color = tmp;
            yield return new WaitForSeconds(.1f);
            tmp.a = 1f;
            playerImage.color = tmp;
            yield return new WaitForSeconds(.1f);
        }
        blinking = false;
    }
}
