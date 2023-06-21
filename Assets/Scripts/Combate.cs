using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combate : MonoBehaviour
{
    public FondoAnim fondoan;
    public int IdFondo = 0;
    public bool exitAnim = false;
    private string atackTipe = "null";
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
        inCombat = true;
        GameManager.instance.GetEnemigo().restartEnemi(GetNewEnemy());
        GameManager.instance.MostrarCombate(true);
        GameManager.instance.GetEnemigo().UpdateAnim();
        StartCoroutine(Wait(0.01f, "fondo"));
    }
    public void fondoDecider()
    {
        Debug.Log("Entro fondoDecider");
        IdFondo = UnityEngine.Random.Range(0, 2);
        exitAnim = false;
        UpdateAnim(IdFondo, exitAnim);
    }
    public bool GetinCombat()
    {
        return inCombat;
    }
    public void UpdateAnim(int IdFondo, bool exitAnim)
    {
        fondoan.UpdateAnim(IdFondo, exitAnim);
    }

    public void toggleBotones(bool bot)
    {
        Debug.Log("entro toggleBotones");
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
                float daño_f = GameManager.instance.GetPlayer().NormalAttack();
                float dañoFinal_f = (daño_f * defensaE);
                GameManager.instance.GetEnemigo().ChangeVida(-dañoFinal_f);
                //toggleBotones(false);
                //Debug.Log("Daño Fis Jug:" + dañoFinal_f);
                break;
            case "ataqueMagico":
                float daño_m = GameManager.instance.GetPlayer().MagicAttack();
                float dañoFinal_m = (daño_m * defensaE);
                GameManager.instance.GetEnemigo().ChangeVida(-dañoFinal_m);
                //Debug.Log("Daño Mag Jug:" + dañoFinal_m);
                break;
        }
    }
    public void newAtack(string attack)
    {
        atackTipe = attack;
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        Debug.Log("Entro newAttack");
        GameManager.instance.SetBotonesCombat(false);
        if (primerTurno())
        {
            Debug.Log("primerTurno "+primerTurno());
            switchAttack(attack);
            if (GameManager.instance.GetEnemigo().EnemigoVidaActual() > 0)
            {
                Debug.Log("newEnemiAttack");
                StartCoroutine(Wait(2, "enemigo"));
                StartCoroutine(Wait(2.1f, "enTurn"));
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
                StartCoroutine(Wait(0.1f, "enemigo"));
                StartCoroutine(Wait(2.1f, "enTurn"));
            }
            else if (GameManager.instance.GetEnemigo().EnemigoVidaActual() < 0)
                StartCoroutine(Wait(2, "enemigoDead"));
            StartCoroutine(Wait(2, "player"));
        }
    }
    public IEnumerator Wait(float seconds, string comand)
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
                float daño_f = GameManager.instance.GetEnemigo().NormalAttackEnem();
                float dañofinal_f = (daño_f * defensaJ);
                GameManager.instance.GetPlayer().ChangeVida(-dañofinal_f);
                //Debug.Log("Daño Fis Ene: " + dañofinal_f);
                break;
            case 1:
                float daño_m = GameManager.instance.GetEnemigo().MagicAttackEnem();
                float dañofinal_m = (daño_m * defensaJ);
                GameManager.instance.GetPlayer().ChangeVida(-dañofinal_m);
                //Debug.Log("Daño Mag Ene: " + dañofinal_m);
                break;
            case 2:
                Debug.Log("ERROR RANDOM MUY LARGO");
                break; 
        }
        //Debug.Log("VIDA Actual Jugador: " + GameManager.instance.GetPlayer().GetVidaActual());
        if (GameManager.instance.GetPlayer().GetVidaActual() <= 0)
            StartCoroutine(Wait(2, "playerDead"));
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
            case "fondo":
                fondoDecider();
                break;
            case "enTurn":
                GameManager.instance.SetBotonesCombat(true);
                break;
            case "player":
                switchAttack(atackTipe);
                break;
        }
    }
}