using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class SFX_Library : MonoBehaviour
{
    [SerializeField] private SFXGroup[] SFXGroups;
    private Dictionary<string, List<AudioClip>> soundDictionary;

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        soundDictionary = new Dictionary<string, List<AudioClip>> ();
        foreach (SFXGroup SFXGroup in SFXGroups) 
        {
            soundDictionary[SFXGroup.name] = SFXGroup.audioClips;
        }
    }
     public AudioClip GetRandomClip (string name) 
    {
    if (soundDictionary.ContainsKey(name)) 
        {
        List<AudioClip> audioClips = soundDictionary[name];
        if (audioClips.Count > 0)
            { return audioClips[UnityEngine.Random.Range(0,audioClips.Count)];
            
            }
        }
    return null;
    }
}

[System.Serializable]

public struct SFXGroup
{
    public string name;
    public List<AudioClip> audioClips;
}