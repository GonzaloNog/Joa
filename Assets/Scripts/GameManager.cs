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

    private int level = 0;
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

    public void CheckGameManager()
    {
        Debug.Log("GameManager is ready");
    }
    public void ChangeLifePlayer(float num)
    {
        player.ChangeVida(num);
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
}
