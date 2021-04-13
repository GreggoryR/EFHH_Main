using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCinematicManager : MonoBehaviour
{
    [SerializeField] Transform tf;
    [SerializeField] GameObject player;

    public void MovePlayer()
    {
        float x = tf.position.x;
        float y = tf.position.y;
        player.gameObject.transform.position = new Vector3(x, y, 0);
    }
}
