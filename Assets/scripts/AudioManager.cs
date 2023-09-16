using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip music;
    public AudioClip shoot;
    public AudioClip error;
    public AudioClip escape;
    public AudioClip victoria;
    public AudioClip[] battle;
    public AudioClip[] hit;

    private AudioSource aud;
    public AudioSource hitPlayer;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.volume = ConfigManager.instance.GetMusicVol();
    }
    public void ChangeMusicNPlay()
    {
        int ran = Random.Range(0,battle.Length);
        aud.clip = battle[ran];
        aud.Play();
    }
    public void PlayHit()
    {
        int ran = Random.Range(0,hit.Length);
        hitPlayer.clip = hit[ran];
        UpdateSound();
        hitPlayer.Play();
    }
    public AudioSource GetAud()
    {
        return aud;
    }
    public void UpdateSound()
    {
        aud.volume = ConfigManager.instance.GetMusicVol();
    }
}
