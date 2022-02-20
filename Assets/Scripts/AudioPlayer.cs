using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume = 1f;
    [Header("Damage Taken")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0, 1)] float damageVolume = 1f;
    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0, 1)] float explosionVolume = 1f;

    // Setup for Singleton pattern
    static AudioPlayer instance;
    // Instance getter
    public AudioPlayer GetInstance()
    {
        return instance;
    }
    // Allow destruction of the audio player from another class
    public void DestroyAudioPlayer()
    {
        Destroy(instance.gameObject);
        instance = null;
    }

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // if (instanceCount > 1)

        // If the instance is already assigned, we can destroy this newly created instance
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        // This instance doesn't exist, create it and tell Unity not to destroy it on load
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    public void PlayExplosionClip()
    {
        PlayClip(explosionClip, explosionVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null) {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
