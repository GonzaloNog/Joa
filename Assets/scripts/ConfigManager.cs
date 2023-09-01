using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager instance;
    private float musicVol = 0.7f;
    private float sfxVol = 0.5f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }
    public float GetMusicVol()
    {
        return musicVol;
    }
    public float GetSfxVol()
    {
        return sfxVol;
    }
    public void SetMusicVol(float vol)
    {
        musicVol = vol;
        GameManager.instance.UpdateSound();
    }
}
