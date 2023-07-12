using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip music;
    public AudioClip shoot;
    public AudioClip error;

    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.clip = music;
        aud.volume = ConfigManager.instance.GetMusicVol();
        aud.Play();
    }
    public AudioClip GetEfectSound(string command)
    {
        switch(command)
        {
            case "shoot":
                return shoot;
            default:
                return error;
        }
    }
    public void UpdateSound()
    {
        aud.volume = ConfigManager.instance.GetMusicVol();
    }
}
