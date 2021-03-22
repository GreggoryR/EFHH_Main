using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Image healthImage;
    bool canAttack;
    bool attckInProgress = false;
    void Start()
    {
        //health.text = GameManager.instance.playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerReceiveDamage") && GameManager.instance.beingChased)
        {
            canAttack = true;
            if (!attckInProgress)
            {
                StartCoroutine(AttackPlayer());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerReceiveDamage"))
        {
            StopCoroutine(AttackPlayer());
            canAttack = false;
            attckInProgress = false;
        }
    }

    IEnumerator AttackPlayer()
    {
        attckInProgress = true;
        while (canAttack)
        {
            yield return new WaitForSeconds(2f);
            if (canAttack)
            {
                RemoveHealth();
            }

                
        }
    }

    private void RemoveHealth()
    {
        GameManager.instance.playerHealth--;
        HealthBroker.HealthIsLostCall();
        if (GameManager.instance.playerHealth == 0)
        {
            Debug.Log("Remove one health -- Health is " + GameManager.instance.playerHealth);
            canAttack = false;
            GameManager.instance.GameOver();
        }
        else
        {
            Debug.Log("Remove one health -- Health is " + GameManager.instance.playerHealth);
        }
        
        
    }
}
