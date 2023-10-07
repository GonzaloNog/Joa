using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Clips
    public AudioClip ambiente;
    public AudioClip escape;
    public AudioClip victoria;
    public AudioClip ding;
    public AudioClip[] battle;
    public AudioClip[] hit;
    //Audio Source 0-musica 1-hitPlayer 2-ambient
    public AudioSource[] audioSource;
    //////////
    public void PlayHit()
    {
        audioSource[1].clip = null;
        audioSource[1].clip = hit[GetRan(hit.Length)];
        AudioSourceControl(1,true);
    }
    public void PlayDing()
    {
        audioSource[1].clip = ding;
        AudioSourceControl(1,true);
    }
    public void PlayEscape()
    {
        audioSource[0].clip = escape;
        AudioSourceControl(0,true);
    }
    public void PlayBattleMusic()
    {
        audioSource[0].clip = null;
        audioSource[0].clip = battle[GetRan(battle.Length)];
        AudioSourceControl(0,true);
    }
    public void AudioSourceControl(int Id, bool value)
    {
        switch (value)
        {
            case true:
                audioSource[Id].Play();
                break;
            case false:
                audioSource[Id].Pause();
                break;
        }
    }
    public int GetRan(int a)
    {
        int ranInt;
        ranInt = Random.Range(0, a);
        return ranInt;
    }
}