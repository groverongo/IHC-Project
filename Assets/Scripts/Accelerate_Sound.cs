using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate_Brake_Sound : MonoBehaviour
{
    public AudioClip accelerate_soundClip; 
    public AudioClip brake_soundClip;
    private float volume = 1.0f; 
    private float fadeOutTime = 1.0f; 
    private AudioSource accelerate_audioSource;
    private AudioSource brake_audioSource;

    void Start()
    {
        accelerate_audioSource = gameObject.AddComponent<AudioSource>();
        brake_audioSource = gameObject.AddComponent<AudioSource>();

        accelerate_audioSource.clip = accelerate_soundClip;
        brake_audioSource.clip = brake_soundClip;

        accelerate_audioSource.volume = volume;
        brake_audioSource.volume = volume;
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
        {
            accelerate_audioSource.volume = volume;
            if (!accelerate_audioSource.isPlaying)
            {
                accelerate_audioSource.Play();
            }
        }
        else if (verticalInput < 0)
        {
            brake_audioSource.volume = volume;
            if (!brake_audioSource.isPlaying) {
                brake_audioSource.Play();
            }
        }
        else
        {
            if (brake_audioSource.isPlaying) {
                brake_audioSource.volume = Mathf.Lerp(brake_audioSource.volume, 0.0f, Time.deltaTime / 2*fadeOutTime);

                if (brake_audioSource.volume < 0.01f)
                {
                    brake_audioSource.Stop();
                }
            }
            if (accelerate_audioSource.isPlaying)
            {
                accelerate_audioSource.volume = Mathf.Lerp(accelerate_audioSource.volume, 0.0f, Time.deltaTime / fadeOutTime);

                if (accelerate_audioSource.volume < 0.01f)
                {
                    accelerate_audioSource.Stop();
                }
            }
        }
    }
}
