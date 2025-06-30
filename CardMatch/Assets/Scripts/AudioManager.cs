using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource bgmSource;
    AudioSource sfxSource;
    public AudioClip bgmClip;
    public AudioClip sfxClip;

    float masterVolume = 1.0f;
    float bgmVolume = 1.0f;
    float sfxVolume = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bgmSource = GetComponent<AudioSource>();
        bgmSource.clip = this.bgmClip;
        bgmSource.Play();
    }

    public void UpdateVolumes()
    {
        if (bgmSource != null)
            bgmSource.volume = masterVolume * bgmVolume;

        if (sfxSource != null)
            sfxSource.volume = masterVolume * sfxVolume;
    }
    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        UpdateVolumes();
    }
    public void SetBgmVolume(float value)
    {
        bgmVolume = value;
        UpdateVolumes();
    }
    public void SetSfxVolume(float value)
    {
        sfxVolume = value;
        UpdateVolumes();
    }
    public float GetSfxVolume()
    {
        return masterVolume * sfxVolume;
    }
}
