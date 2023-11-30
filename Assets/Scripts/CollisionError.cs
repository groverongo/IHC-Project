using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionError : MonoBehaviour
{
    // S
    // tart is called before the first frame update

    public AudioClip collision_sound;
    public AudioSource collision_source;

    void Start()
    {
        collision_source = gameObject.AddComponent<AudioSource>();
        collision_source.clip = collision_sound;
        collision_source.loop = true;
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("COLISIONES");
        if (!collision_source.isPlaying)
        {
            collision_source.Play();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision_source.isPlaying)
        {
            collision_source.Stop();
        }    
    }
}
