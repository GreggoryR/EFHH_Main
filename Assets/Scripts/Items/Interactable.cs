///////////////////////////////////////////////////////////////////////////
//FileName: Interactable.cs
//Author : Greggory Reed
//Description : Class for iteracting with items
////////////////////////////////////////////////////////////////////////////
///
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
