using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager Instance;

    private static AudioSource audiosource;
    public AudioClip backgroundMusic;
    [SerializeField] private Slider musicSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audiosource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(backgroundMusic != null)
        {
            PlayBackgroundMusic(false, backgroundMusic);
        }

        musicSlider.onValueChanged.AddListener(delegate { SetVolume(musicSlider.value); });

    }

    public static void SetVolume(float volume)
    {
        MusicManager.audiosource.volume = volume;
    }

    public void PlayBackgroundMusic(bool resetSong,AudioClip audioClip = null)
    {
        if(audioClip != null)
        {
            audiosource.clip = audioClip;
        }
        else if(audiosource != null) 
        { 
            if(resetSong) { audiosource.Stop();
                    }
            audiosource.Play();
    }

    }
}
