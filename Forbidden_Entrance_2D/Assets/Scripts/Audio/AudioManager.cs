using JetBrains.Annotations;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("----Audio Source----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----Audio Clip----")]
    // Array to store background music options for each level (ensure you add 4 clips in the Inspector)
    public AudioClip[] backgroundMusicOptions;

//public AudioClip background;
public AudioClip death;
public AudioClip checkpoint;
public AudioClip portalIn;
public AudioClip portalOut;

private void Start()
{
        // Get the current scene index
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        // If there is a corresponding background music clip in the array, use it.
        if (backgroundMusicOptions != null && backgroundMusicOptions.Length > sceneIndex)
        {
            musicSource.clip = backgroundMusicOptions[sceneIndex];
        }
        else
        {
            UnityEngine.Debug.LogWarning("No background music assigned for this scene index. Please assign a clip in the backgroundMusicOptions array.");
        }

        // Ensure the music loops and then play it.
        musicSource.loop = true;
        musicSource.Play();
}

    public void PlaySFX(AudioClip clip)
    {
        // Play the SFX on its own AudioSource so that it doesn't interrupt the background music.
        if (clip != null)
            SFXSource.PlayOneShot(clip);
    }
}