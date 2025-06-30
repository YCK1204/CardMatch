using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    match = 0,
    flip = 1
}

public class SoundManager_seyun : MonoBehaviour
{
    public static SoundManager_seyun Instance;

    AudioSource audioSource;
    public AudioClip[] clips = new AudioClip[2];

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffectSound(Sound sound)
    {
        switch (sound)
        {
            case Sound.match:
                audioSource.PlayOneShot(clips[0]);
                break;
            case Sound.flip:
                audioSource.PlayOneShot(clips[1]);
                break;
        }
    }
}
