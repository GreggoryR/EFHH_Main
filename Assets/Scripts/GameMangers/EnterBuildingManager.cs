///////////////////////////////////////////////////////////////////////////
//FileName: EnterBuildingManager.cs
//Author : Greggory Reed
//Description : Will updated environment and radar when entering the building
///////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class EnterBuildingManager : MonoBehaviour
{
    [SerializeField] GameObject roofFade;
    [SerializeField] GameObject outsideFade;
    [SerializeField] GameObject exitTransform;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnterExitBroker.PlayerEntersBuildingFunction();
            roofFade.SetActive(false);
            outsideFade.GetComponent<SpriteRenderer>().sortingLayerName = "Infront_All";
            exitTransform.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
