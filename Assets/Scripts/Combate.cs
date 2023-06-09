using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combate : MonoBehaviour
{
    [System.Serializable]
    public struct Dificultad
    {
        public string[] enemigos;
    }
    private bool inCombat = false;
    public Dificultad[] enemigos;

    void Start()
    {
        this.gameObject.SetActive(false);
        GameManager.instance.finishLevel = enemigos.Length + 1;
    }

    public void newCombat()
    {
        inCombat = true;
        GameManager.instance.GetEnemigo().restartEnemi(GetNewEnemy());
        GameManager.instance.MostrarCombate(true);
    }

    public bool GetinCombat()
    {
        return inCombat;
    }

    public void newAtack(string attack)
    {
        switch (attack)
        {
            case "ataqueNormal":
                float da�o_f = GameManager.instance.GetPlayer().NormalAttack();
                GameManager.instance.GetEnemigo().ChangeVida(-da�o_f);
                Debug.Log("Da�o Fis Jug:" + da�o_f);
            break;
            case "ataqueMagico":
                float da�o_m = GameManager.instance.GetPlayer().MagicAttack();
                GameManager.instance.GetEnemigo().ChangeVida(-da�o_m);
                Debug.Log("Da�o Mag Jug:" + da�o_m);
            break;
        }
        if (GameManager.instance.GetEnemigo().EnemigoVidaActual() > 0)
            newEnemiAtack();
        else
            endCombat(true);
    }
    public void newEnemiAtack()
    {
       int a = Random.Range(0,2);
       switch(a)
        {
            case 0:
                float da�o_f = GameManager.instance.GetEnemigo().NormalAttackEnem();
                GameManager.instance.GetPlayer().ChangeVida(-da�o_f);
                Debug.Log("Da�o Fis Ene: " + da�o_f);
                break;
            case 1:
                float da�o_m = GameManager.instance.GetEnemigo().MagicAttackEnem();
                GameManager.instance.GetPlayer().ChangeVida(-da�o_m);
                Debug.Log("Da�o Mag Ene: " + da�o_m);
                break;
            case 2:
                Debug.Log("ERROR RANDOM MUY LARGO");
                break; 
        }
        Debug.Log("VIDA: " + GameManager.instance.GetPlayer().GetVidaActual());
        if (GameManager.instance.GetPlayer().GetVidaActual() <= 0)
            endCombat(false);
    }
    public void endCombat(bool win)
    {
        if(win)
        {
            GameManager.instance.changelevel = true;
            GameManager.instance.GetPlayer().ChangeExp(GameManager.instance.GetEnemigo().expEne);
            GameManager.instance.MostrarCombate(false);
        }
        else
        {
            GameManager.instance.MostrarCombate(false);
            GameManager.instance.EndGame(true);
        }
    }
    public string GetNewEnemy()
    {
        int a = Random.Range(0, enemigos[GameManager.instance.nivelActual].enemigos.Length);
        return enemigos[GameManager.instance.nivelActual].enemigos[a];
    }
}