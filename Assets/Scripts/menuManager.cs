using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public Slider musicVolum; 
    public void PlayGame()
    {
        SceneManager.LoadScene("nivel1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeSlider()
    {
        ConfigManager.instance.SetMusicVol(musicVolum.value);
    }
}
