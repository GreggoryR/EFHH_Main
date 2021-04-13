//////////////////////////////////////////////////////////////
//FileName: VentCinematicManager.cs
//Author : Greggory Reed
//Description : Plays the cinematic after the vent minigame
////////////////////////////////////////////////////////////////////////////

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
