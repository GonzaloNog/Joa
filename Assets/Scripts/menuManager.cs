using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("nivel1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
