////////////////////////////////////////////////////////////////////////////
//FileName: PlayerFound.cs
//Author : Greggory Reed
//Description : Class for detecting the player and activating correct events
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using UnityEngine;
using System;

public class PlayerFound : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] GameObject playerLost;
    [SerializeField] GameObject parentEnemy;
    [SerializeField] GameObject enemyAttack;
    [SerializeField] GameObject getStunned;
    [SerializeField] GameObject radarColor;

    [Header("Transform")]
    [SerializeField] Transform enemyPosition;

    [Header("Chase Cinematics")]
    [SerializeField] GameObject ui_chase_canvas;
    [SerializeField] Animator ui_image_animator;
    [SerializeField] AudioClip scaryFound;
    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] GameObject radarMap;

    private bool playerInCircle = false;
    IEnumerator FindWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInCircle = true;
            FindWall = FindPlayerOrWall(collision);
            StartCoroutine(FindWall);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            try
            {
                StopCoroutine(FindWall);
            }
            catch (Exception)
            {
                throw;
            }
            playerInCircle = false;
        }
    }
    private IEnumerator FindPlayerOrWall(Collider2D collision)
    {
        if (playerInCircle && !GameManager.instance.beingChased)
        {
            LayerMask nm = LayerMask.GetMask("Radar"); //need to convert the layer to bitwise with <<
            RaycastHit2D hit = Physics2D.Linecast(enemyPosition.position, collision.transform.position, nm);
            if (!hit)
            {
                ChasePlayer();
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(.5f);
                yield return StartCoroutine(FindPlayerOrWall(collision));
            }
        }
    }
    private void ChasePlayer()
    {
        playerLost.SetActive(true);
        enemyAttack.SetActive(true);
        getStunned.SetActive(true);
        radarColor.GetComponent<SpriteRenderer>().color = Color.red;
        GameManager.instance.beingChased = true;
        parentEnemy.GetComponent<EnemyController>().GenerateDestination();
        GameManager.instance.theChasers.Add(this.GetComponentInParent<Transform>().gameObject);
        //radar.SetActive(false);
        //playerAudioSource.clip = scaryFound;
        //playerAudioSource.Play();
        //ui_chase_canvas.SetActive(true);
        //ui_image_animator.Play("UI_chase_ani");
        gameObject.SetActive(false);
    }
}
