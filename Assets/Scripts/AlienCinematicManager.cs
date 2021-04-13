using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AlienCinematicManager : MonoBehaviour
{
    public static AlienCinematicManager instance;

    [SerializeField] PlayableDirector pb;
    [SerializeField] Transform tf;
    [SerializeField] GameObject player;
    [SerializeField] GameObject alien;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Begin()
    {
        float x = tf.position.x;
        float y = tf.position.y;
        player.gameObject.transform.position = new Vector3(x, y, 0);
        MusicManager.instance.ChangeSong(MusicManager.Songs.scary);
        pb.Play();
    }

    public void StartAlien()
    {
        alien.SetActive(true);
    }
}
