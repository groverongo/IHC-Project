using UnityEngine;

public class Start_Engine : MonoBehaviour
{
    public AudioClip soundClip; // The audio clip to be played
    private AudioSource audioSource;

    void Start()
    {
        Debug.Log("ENGINE ON");
        // Add an AudioSource component to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();

        // Set the AudioClip to the AudioSource
        audioSource.clip = soundClip;
        audioSource.volume = 1;

        // Play the sound
        audioSource.Play();
    }
}
