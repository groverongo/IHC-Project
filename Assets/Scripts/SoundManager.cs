using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    #region --- helper ---
    [System.Serializable]
    public struct Sound_Declaration {
        public AudioClip soundClip;
        public AudioSource audioSource;
    };
    #endregion

    public Sound_Declaration Engine_Start;
    public Sound_Declaration Acceleration;
    public Sound_Declaration Brake;
    private float volume= 1.0f;
    private float fadeOutTime = 1.0f;

    void initialize_engine_start() {
        Engine_Start.audioSource = gameObject.AddComponent<AudioSource>();
        Engine_Start.audioSource.clip = Engine_Start.soundClip;
        Engine_Start.audioSource.Play();
    }

    void initialize_acceleration()
    {
        Acceleration.audioSource = gameObject.AddComponent<AudioSource>();
        Acceleration.audioSource.clip = Acceleration.soundClip;
        Acceleration.audioSource.volume = volume;
    }

    void acceleration_gain(float axis) {
        if (axis > 0)
        {
            Acceleration.audioSource.volume = volume;
            if (!Acceleration.audioSource.isPlaying)
            {
                Acceleration.audioSource.Play();
            }
        }
        else
        {
            if (Acceleration.audioSource.isPlaying)
            {
                Acceleration.audioSource.volume = Mathf.Lerp(Acceleration.audioSource.volume, 0.0f, Time.deltaTime / fadeOutTime);

                if (Acceleration.audioSource.volume < 0.01f)
                {
                    Acceleration.audioSource.Stop();
                }
            }
        }
    }

    void initialize_brake()
    {
        Brake.audioSource = gameObject.AddComponent<AudioSource>();
        Brake.audioSource.clip = Brake.soundClip;
        Brake.audioSource.volume = volume;
    }

    void brake_gain(float axis) {
        if (axis < 0)
        {
            Brake.audioSource.volume = volume;
            if (!Brake.audioSource.isPlaying)
            {
                Brake.audioSource.Play();
            }
        }
        else
        {
            if (Brake.audioSource.isPlaying)
            {
                Brake.audioSource.volume = Mathf.Lerp(Brake.audioSource.volume, 0.0f, 2*Time.deltaTime /  fadeOutTime);

                if (Brake.audioSource.volume < 0.01f)
                {
                    Brake.audioSource.Stop();
                }
            }
        }
    }

    void Start()
    {
        initialize_engine_start();
        initialize_acceleration();
        initialize_brake();
    }

    private void Update()
    {
        float vertical_input = Input.GetAxis("Vertical");
        acceleration_gain(vertical_input);
        brake_gain(vertical_input);
    }
}
