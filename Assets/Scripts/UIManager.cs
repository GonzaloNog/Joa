using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject tooltip;
    public GameObject menu;
    public Slider vida;
    public TextMeshProUGUI enemiName;
    public TextMeshProUGUI nivelUI;
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
    public GameObject textoNotificacion;
    public GameObject pausaMenu;

    public Slider[] sliderVolumen;

    public TextMeshProUGUI mitadCamino;
    public GameObject mitadObject;
    public ConfigManager cfgMgr;
    public GameObject player;
    private float i;
    private bool timer;
    private bool timer2;
    public GameObject menuConfig;
    public AnimationClip clip;
    public TextMeshProUGUI manaCounter;
    public TextMeshProUGUI cambCamino;

    private bool x = true;
    private void Start()
    {
        UpdateLevelUI();
        UpdateSlidersVolumen();
    }
    public void Update()
    {
        if(this.gameObject.scene == SceneManager.GetSceneByName("nivel1"))
        {
            string currMana = GameManager.instance.GetPlayer().mana.ToString();
            string currManaMax = GameManager.instance.GetPlayer().manaMax.ToString();
            string textoMana = (currMana+"/"+currManaMax);
            manaCounter.text = textoMana;
        }
        //timers
        if (timer)
        {
            i+= Time.deltaTime;
            if(i>=clip.length)
            {
                timer = false;
                i=0;
                timer2 = true;
                player.GetComponent<Animator>().SetBool("levantarse",false);
            }
        }
        if(timer2)
        {
            i+=Time.deltaTime;
            if(i>=1)
            {
                SceneManager.LoadScene("nivel1");
            }
        }
    }
    public void PlayGame()
    {
        player.GetComponent<Animator>().SetBool("levantarse", true);
        timer = true;
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
    //
    public void UpdateSlidersVolumen()
    {
        for (int i = 0; i<sliderVolumen.Length;i++)
        {
            sliderVolumen[i].value = cfgMgr.volumen[i];
        }
    }
    public void UpdateVolumen(int a)
    {
        cfgMgr.volumen[a] = sliderVolumen[a].value;
        SetVolumen(a,sliderVolumen[a].value);
    }
    public void SetVolumen(int id,float value)
    {
        GameManager.instance.GetAudioManager().audioSource[id].volume = value;
    }
    public void UpdateTimerMdC(string a)
    {
        mitadCamino.text = a;
    }
    public void UIWin()
    {
        win.SetActive(!win.activeSelf);
        nivelUI.gameObject.SetActive(!nivelUI.gameObject.activeSelf);
        mitadCamino.gameObject.SetActive(!win.activeSelf);
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
    public void Notificacion(string texto)
    {
        textoNotificacion.GetComponent<textoNotificacion>().SendText(texto);
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
    public void AtaqueMagUI(string attack)
    {
        int manaCost = 0;

        switch(attack)
        {
            case "fire":
            manaCost = GameManager.instance.GetCombate().manaFire;
            break;
            case "ice":
            manaCost = GameManager.instance.GetCombate().manaIce;
            break;
            case "light":
            manaCost = GameManager.instance.GetCombate().manaLight;
            break;
            default:
            break;
        }
        if (manaCost <= GameManager.instance.GetPlayer().mana)
        {    
            GameManager.instance.GetCombate().newAtack(attack);
        }
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
    public void TogglePausa()
    {
        pausaMenu.gameObject.SetActive(!pausaMenu.activeSelf);
        UpdateSlidersVolumen();
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
        print("newLevel");
        int point = Random.Range(0, GameManager.instance.GetSpawnOBJ().points.Length);
        int obj = Random.Range(0, GameManager.instance.GetSpawnOBJ().prefads.Length);
        nivelUI.alpha = 1;
        GameManager.instance.GetSpawnOBJ().newSpawn(point, obj);
        if(GameManager.instance.changelevel)
        {
            GameManager.instance.NewLevel();
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
        if(this.gameObject.scene == SceneManager.GetSceneByName("nivel1"))
        nivelUI.text = GameManager.instance.nivelActual.ToString();
    }
    public void tooltipMana(string a)
    {
        switch(a)
        {
            case"fire": tooltip.GetComponent<TextMeshProUGUI>().text = "Mana: " + GameManager.instance.GetCombate().manaFire.ToString();
            break;
            case"light": tooltip.GetComponent<TextMeshProUGUI>().text = "Mana: " + GameManager.instance.GetCombate().manaLight.ToString();
            break;
            case"ice": tooltip.GetComponent<TextMeshProUGUI>().text = "Mana: " + GameManager.instance.GetCombate().manaIce.ToString();
            break;
            default:
            break;
        }
    }
    public void tooltipManaExit()
    {
        tooltip.GetComponent<TextMeshProUGUI>().text = "";
    }
}