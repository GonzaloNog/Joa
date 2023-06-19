using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combate : MonoBehaviour
{
    private UIManager UI;
    private activar_botones botones;
    public int IdFondo = 0;
    public bool exitAnim = false;
    // esto
    [System.Serializable]
    public struct Dificultad
    {
        public string[] enemigos;
    }
    private bool inCombat = false;
    public Dificultad[] enemigos;
    // esto
    void Start()
    {
        this.gameObject.SetActive(false);
        GameManager.instance.finishLevel = enemigos.Length + 1;
    }

    public void newCombat()
    {
        fondoDecider();
        inCombat = true;
        GameManager.instance.GetEnemigo().restartEnemi(GetNewEnemy());
        GameManager.instance.MostrarCombate(true);
        GameManager.instance.GetEnemigo().UpdateAnim();
    }
    public void fondoDecider()
    {
        IdFondo = UnityEngine.Random.Range(0, 2);
        exitAnim = false;
        GameManager.instance.GetFondoAnim().UpdateAnim(IdFondo, exitAnim);

    }
    public bool GetinCombat()
    {
        return inCombat;
    }


    public void toggleBotones(bool bot)
    {
        Debug.Log("entro toggleBotones");
        botones.ActivarBotones(bot);
    }
    public bool primerTurno()
    {
        float speedJugador = GameManager.instance.GetPlayer().speed;
        float speedEnemigo = GameManager.instance.GetEnemigo().GetEnemySpeed();
        bool primerturno;
        if (speedJugador > speedEnemigo)
        {
            primerturno = true;
        }
        else
        {
            primerturno = false;
        }
        Debug.Log("speedJugador "+speedJugador);
        Debug.Log("speedEnemigo "+speedEnemigo);
        return primerturno;
        
    }
    public void switchAttack(string attack)
    {
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        switch (attack)
        {
            case "ataqueNormal":
                float da�o_f = GameManager.instance.GetPlayer().NormalAttack();
                float da�oFinal_f = (da�o_f * defensaE);
                GameManager.instance.GetEnemigo().ChangeVida(-da�oFinal_f);
                //toggleBotones(false);
                //Debug.Log("Da�o Fis Jug:" + da�oFinal_f);
                break;
            case "ataqueMagico":
                float da�o_m = GameManager.instance.GetPlayer().MagicAttack();
                float da�oFinal_m = (da�o_m * defensaE);
                GameManager.instance.GetEnemigo().ChangeVida(-da�oFinal_m);
                //Debug.Log("Da�o Mag Jug:" + da�oFinal_m);
                break;
        }
    }
    public void newAtack(string attack)
    {
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        Debug.Log("Entro newAttack");

        if (primerTurno())
        {
            Debug.Log("primerTurno "+primerTurno());
            switchAttack(attack);
            if (GameManager.instance.GetEnemigo().EnemigoVidaActual() > 0)
            {
                Debug.Log("newEnemiAttack");
                StartCoroutine(Wait(2, "enemigo"));
            }
            else if (GameManager.instance.GetEnemigo().EnemigoVidaActual() < 0)
                StartCoroutine(Wait(2, "enemigoDead"));
        }
        else if (primerTurno() == false)
        {
            Debug.Log("primerTurno " + primerTurno());
            if (GameManager.instance.GetEnemigo().EnemigoVidaActual() > 0)
            {
                Debug.Log("newEnemiAttack");
                StartCoroutine(Wait(2, "enemigo"));
            }
            else if (GameManager.instance.GetEnemigo().EnemigoVidaActual() < 0)
                StartCoroutine(Wait(2, "enemigoDead"));
            switchAttack(attack);
        }
    }
    public IEnumerator Wait(int seconds, string comand)
    {
        //Debug.Log("Wait");
        yield return new WaitForSeconds(seconds);
        timeComands(comand);
    }
    public void newEnemiAtack()
    {

       float defensaJ = DefToDR(GameManager.instance.GetPlayer().defensa);
       int a = UnityEngine.Random.Range(0,2);
       switch(a)
        {
            case 0:
                float da�o_f = GameManager.instance.GetEnemigo().NormalAttackEnem();
                float da�ofinal_f = (da�o_f * defensaJ);
                GameManager.instance.GetPlayer().ChangeVida(-da�ofinal_f);
                //Debug.Log("Da�o Fis Ene: " + da�ofinal_f);
                break;
            case 1:
                float da�o_m = GameManager.instance.GetEnemigo().MagicAttackEnem();
                float da�ofinal_m = (da�o_m * defensaJ);
                GameManager.instance.GetPlayer().ChangeVida(-da�ofinal_m);
                //Debug.Log("Da�o Mag Ene: " + da�ofinal_m);
                break;
            case 2:
                Debug.Log("ERROR RANDOM MUY LARGO");
                break; 
        }
        //Debug.Log("VIDA Actual Jugador: " + GameManager.instance.GetPlayer().GetVidaActual());
        if (GameManager.instance.GetPlayer().GetVidaActual() <= 0)
            StartCoroutine(Wait(2, "playerDead"));
        botones.ActivarBotones(true);
    }
    public void endCombat(bool win)
    {
        exitAnim = true;
        GameManager.instance.GetFondoAnim().UpdateAnim(0,exitAnim);
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
        //random sin UnityEngine. daba cs0104
        int a = UnityEngine.Random.Range(0, enemigos[GameManager.instance.nivelActual].enemigos.Length);
        return enemigos[GameManager.instance.nivelActual].enemigos[a];
    }
    public float DefToDR(float defense)
    {
        float reduction = 100 / (defense + 100);
        return reduction;
    }

    public void timeComands(string comand)
    {
        Debug.Log("timeComands" + comand);
        switch (comand)
        {
            case "enemigoDead":
                endCombat(true);
                break;
            case "playerDead":
                endCombat(false);
                break;
            case "enemigo":
                newEnemiAtack();
                break;
        }
    }
}