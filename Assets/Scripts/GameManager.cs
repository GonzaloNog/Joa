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
    public Obj obj;
    public int nivelActual = 1;
    public bool changelevel = true;
    public int finishLevel = 0;
    private bool mitadDeCamino = false;

    private int level = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);

        //DontDestroyOnLoad(this);
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
    public void NextLevel()
    {
        level++;
    }
    public void ChangeVidaPLayer()
    {
        UI.UpdateVidaUI();
    }
    public void ChangeVidaEnemigo()
    {
        UI.UpdateVidaEnemigo();
    }
    public void MostrarCombate(bool com)
    {
        UI.ActivarCombate(com);
    }
    public void EndGame(bool com)
    {
        UI.SetEndGame(com);
    }
    public void SetBotonesCombat(bool boot)
    {
        UI.ActivarBotones(boot);
    }
    public void NewLevel()
    {
        if (nivelActual == finishLevel)
        {
            mitadDeCamino = true;
        }
        if (nivelActual == 1 && mitadDeCamino)
            WinGame();
        else if (changelevel)
        {
            UI.ChangeBackgroundRandom();
            if (!mitadDeCamino)
                nivelActual++;
            else
                nivelActual--;
            changelevel = false;
            comb.newCombat();
        }

    }
    public void WinGame()
    {

    }
}
