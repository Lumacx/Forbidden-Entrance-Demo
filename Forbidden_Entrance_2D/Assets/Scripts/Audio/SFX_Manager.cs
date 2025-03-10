using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SFX_Manager : MonoBehaviour
{
    private static SFX_Manager instance;

    private static AudioSource audiosource;
    private static SFX_Library soundEffectLibrary;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    { if (instance == null)
        {
            instance = this;
            audiosource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SFX_Library>();
            DontDestroyOnLoad(gameObject);
        }      
       else
        { 
            Destroy(gameObject); 
        }
     }

    public static void Play(string soundName)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null)
        {
            audiosource.PlayOneShot(audioClip);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });  
    }

    public static void SetVolume(float volume)
    {
        audiosource.volume = volume;
    }

    public void OnValueChanged()
    {
        SetVolume(sfxSlider.value);
    }

}
