using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Personaje player;
    public Enemigo enemigo;
    public Background fondo;
    public UIManager UI;
    public Combate comb;
    public FondoAnim fondoanim;
    public spawnOBJ spawn;
    public AudioManager sfx;
    public GameObject camera;
    public ConfigManager config;
    public int nivelActual = 1;
    public bool changelevel = true;
    public int finishLevel = 0;
    public bool mitadDeCamino = false;
    public GameObject Pendiente;
    private int level = 0;

    public float mitadDeCaminoTimer;
    private float i;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    private void Update()
    {
        if(mitadDeCamino)
        {
            i += Time.deltaTime;
            if (i > mitadDeCaminoTimer)
            {
                EndGame(true);
            }
            else
            {
                UI.mitadObject.gameObject.SetActive(true);
                UI.UpdateTimerMdC((mitadDeCaminoTimer - i).ToString("0.##"));
            }
        }
    }
    public void Start()
    {
        changelevel = true;
        // GameManager.instance.GetCombate().newCombat();
    }
    public Background GetBackground()
    {
        return fondo;
    }
    public ConfigManager GetConfigManager()
    {
        return config;
    }
    public GameObject GetPendiente()
    {
        return Pendiente;
    }
    public Personaje GetPlayer()
    {
        return player;
    }
    public Enemigo GetEnemigo()
    {
        return enemigo;
    }
    public Combate GetCombate()
    {
        return comb;
    }
    public FondoAnim GetFondoAnim()
    {
        return fondoanim;
    }
    public spawnOBJ GetSpawnOBJ()
    {
        return spawn;
    }
    public AudioManager GetAudioManager()
    {
        return sfx;
    }
    public void NextLevel()
    {
        level++;
    }
    public void ChangeVidaPLayer()
    {
        UI.UpdateVidaUI();
    }
    public void MostrarCombate(bool com)
    {
        UI.ActivarCombate(com);
    }
    public void EndGame(bool com)
    {
        UI.mitadObject.gameObject.SetActive(false);
        UI.SetEndGame(com);
    }
    public void SetBotonesCombat(bool boot)
    {
        UI.ActivarBotones(boot);
    }
    public bool NewLevel()
    {
        if (nivelActual == 1 && mitadDeCamino)
            WinGame();
        else if (changelevel)
        {
            UI.ChangeBackgroundRandom();
            if (!mitadDeCamino)
                nivelActual++;
            else
            {
                nivelActual--;
            }
            changelevel = false;
            comb.newCombat();
            //UI.UpdateLevelUI();
        }
        return changelevel;
    }
    public void WinGame()
    {
        for (int i = 0; i<sfx.audioSource.Length; i++)
            sfx.audioSource[i].Pause();
        UI.UIWin();
    }
}
 