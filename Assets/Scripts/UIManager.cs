using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject menu;
    public Slider vida;
    public Slider vidaEnemigo;
    public TextMeshProUGUI enemiName;
    public GameObject itemsSubMenu;
    public GameObject combate;
    public GameObject endGame;
    public GameObject botones;
    public GameObject menuEstadisticas;
    private void Start()
    {
        itemsSubMenu.SetActive(false);
    }
    public void ActivarCombate(bool com)
    {
        combate.gameObject.SetActive(com);
        ActivarBotones(com);
        //GameManager.instance.GetCombate().fondoDecider();
    }
    public void ChangeBackgroundRandom()
    {
        int a = Random.Range(0, GameManager.instance.GetBackground().cantBackgrounds());
        GameManager.instance.GetBackground().setIdBackground(a);
        GameManager.instance.GetBackground().CambiarFondo();
    }

    public void changeColor(string colorName)
    {
        GameManager.instance.GetBackground().ChangeColor(colorName);
    }
    public void AtaqueUI(string attack)
    {
        Debug.Log("AtaqueUI: " + attack);
        GameManager.instance.GetCombate().newAtack(attack);
    }
    public void changeVisionItems()
    {
        itemsSubMenu.SetActive(!itemsSubMenu.activeSelf);
    }
    public void ChangeVisionMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }
    public void UpdateVidaUI()
    {
        vida.minValue = 0;
        vida.maxValue = GameManager.instance.GetPlayer().vidaMaxima;
        vida.value = GameManager.instance.GetPlayer().GetVidaActual();
    }
    public void UpdateVidaEnemigo()
    {
        if (GameManager.instance.GetCombate().GetinCombat())
        {
            vidaEnemigo.minValue = 0;
            vidaEnemigo.maxValue = GameManager.instance.GetEnemigo().vidaEne;
            vidaEnemigo.value = GameManager.instance.GetEnemigo().EnemigoVidaActual();
            enemiName.text = GameManager.instance.GetEnemigo().nameEne;
        }
    }
    public void goMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void SetEndGame(bool game)
    {
        endGame.SetActive(game);
    }
    public void NewLevel()
    {
        GameManager.instance.NewLevel();
    }
    public void ActivarBotones(bool bot)
    {
        botones.SetActive(bot);
    }

    public void SetMenuEstadisticas(bool con)
    {
        menuEstadisticas.SetActive(con);
    }
}
