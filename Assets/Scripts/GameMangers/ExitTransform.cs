using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTransform : MonoBehaviour
{
    [SerializeField] GameObject roofFade;
    [SerializeField] GameObject outsideFade;
    [SerializeField] GameObject enterTransform;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnterExitBroker.PlayerExitsBuildingFunction();
            roofFade.SetActive(true);
            outsideFade.GetComponent<SpriteRenderer>().sortingLayerName = "Behind_All";
            enterTransform.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
