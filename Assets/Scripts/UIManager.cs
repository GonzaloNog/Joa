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
    public TextMeshProUGUI enemiName;
    public TextMeshProUGUI nivelUI;
    private TextMeshProUGUI textoObjetos;
    public GameObject itemsSubMenu;
    public GameObject magiaSubmenu;
    public GameObject combate;
    public GameObject endGame;
    public GameObject botones;
    public GameObject ataque;
    public GameObject escapar;
    public GameObject menuEstadisticas;
    public GameObject win;
    public GameObject barra;

    public GameObject[] estadisticasNumeros;
    private void Start()
    {
        UpdateLevelUI();
    }
    private void Update()
    {
    }
    public void UIWin()
    {
        win.SetActive(!win.activeSelf);
        nivelUI.gameObject.SetActive(!nivelUI.gameObject.activeSelf);
    }
    private void TextoObjetos()
    {
        //textoObjetos.isActiveAndEnabled = false;
    }
    public void UpdatePuntosUI()
    {
        estadisticasNumeros[0].GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayer().vidaMaxima.ToString();
        estadisticasNumeros[1].GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayer().fuerza.ToString();
        estadisticasNumeros[2].GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayer().inteligencia.ToString();
        estadisticasNumeros[3].GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayer().speed.ToString();
        estadisticasNumeros[4].GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayer().defensa.ToString();
        estadisticasNumeros[5].GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayer().GetPoints().ToString();
    }
    public void ActivarCombate(bool com)
    {
        combate.SetActive(com);
        ActivarBotones(com);
        barra.SetActive(false);
        menuEstadisticas.SetActive(false);

        GameManager.instance.GetCombate().fondoDecider();
    }
    public void EndCombat()
    {
        barra.SetActive(true);
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
        GameManager.instance.GetCombate().newAtack(attack);
    }
    public void MagiaSubmenu()
    {
        magiaSubmenu.SetActive(!magiaSubmenu.activeSelf);
        ataque.SetActive(!ataque.activeSelf);
        escapar.SetActive(!escapar.activeSelf);
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
        if (!GameManager.instance.NewLevel())
        {
            int point = Random.Range(0, GameManager.instance.GetSpawnOBJ().points.Length);
            int obj = Random.Range(0, GameManager.instance.GetSpawnOBJ().prefads.Length);
            GameManager.instance.GetSpawnOBJ().newSpawn(point, obj);
        }
    }
    public void ActivarBotones(bool bot)
    {
        botones.SetActive(bot);

        magiaSubmenu.SetActive(false);
        ataque.SetActive(true);
        escapar.SetActive(true);


    }

    public void SetMenuEstadisticas(bool con)
    {
        if (!GameManager.instance.GetCombate().GetinCombat())
        {
            menuEstadisticas.SetActive(con);
            menuEstadisticas.GetComponent<MenuEstadisticas>().Open();
        }
    }
    public void UpdateLevelUI()
    {
        nivelUI.text = GameManager.instance.nivelActual.ToString();
    }
}