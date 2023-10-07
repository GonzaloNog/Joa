using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public GameObject player;
    private float i;
    private bool timer;
    public GameObject menuConfig;
    public AnimationClip clip;
    public void PlayGame()
    {
        player.GetComponent<Animator>().SetBool("levantarse", true);
        timer = true;
    }
    public void Update()
    {
        if (timer)
        {
            i+= Time.deltaTime;
            if(i>=clip.length+1)
            {
                timer = false;
                SceneManager.LoadScene("nivel1");
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToggleMenuConfig()
    {
        menuConfig.SetActive(!menuConfig.activeSelf);
    }
    public void ChangeSlider()
    {
        //ConfigManager.instance.SetMusicVol(musicVolum.value);
    }
}
