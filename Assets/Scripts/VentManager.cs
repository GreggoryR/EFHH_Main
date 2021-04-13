using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentManager : MonoBehaviour
{
    [SerializeField] GameObject playerButtonCanvas;
    [SerializeField] GameObject ventMinigame;
    [SerializeField] GameObject pd;

    bool canUse;


    public void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Chapter_3_b_Basement") && canUse && Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.instance.sawAlien)
            {
                ventMinigame.SetActive(true);
                canUse = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.sawAlien && collision.CompareTag("PlayerFoundCollider"))
        {
            canUse = true;
            playerButtonCanvas.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFoundCollider"))
        {
            playerButtonCanvas.SetActive(false);
        }

    }

    public void BeginVentCrawl()
    {
        pd.SetActive(true);
        ventMinigame.SetActive(false);
    }
}
