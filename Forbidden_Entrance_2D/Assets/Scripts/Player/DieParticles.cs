using System.Diagnostics;
using UnityEngine;

public class DieParticleManager : MonoBehaviour
{
    public static DieParticleManager Instance; // Singleton instance
    [Header("Die Particle Effect")]
    public ParticleSystem dieParticleEffect; // Assign via Inspector

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes

            if (dieParticleEffect == null)
            {
                UnityEngine.Debug.LogError("Die Particle Effect not assigned in DieParticleManager!");
            }
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    /// <summary>
    /// Plays the die effect at a specified position.
    /// </summary>
    /// <param name="position">The world position where the effect should be displayed.</param>
    public void PlayDieEffect(Vector3 position)
    {
        if (dieParticleEffect != null)
        {
            // Update the particle system's position to the target position.
            dieParticleEffect.transform.position = position;

            // If it's already playing, stop and clear it before replaying.
            if (dieParticleEffect.isPlaying)
            {
                dieParticleEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
            dieParticleEffect.Play();
        }
        else
        {
            UnityEngine.Debug.LogError("Die Particle Effect is not assigned!");
        }
    }
}
