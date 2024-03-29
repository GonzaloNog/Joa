using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Combate : MonoBehaviour
{
    public FondoAnim fondoan;
    public int IdFondo = 0;
    public bool exitAnim = false;
    private string atackTipe = "null";
    private bool escape;
    public int manaFire;
    public int manaIce;
    public int manaLight;
    public JugadorAnim jugAnim;
    // esto
    [System.Serializable]
    public struct Dificultad
    {
        public string[] enemigos;
    }
    private bool inCombat = false;
    public Dificultad[] enemigos;
    public void newCombat()
    {
        //jugAnim.ResetAnimNumeros();
        inCombat = true;
        GameManager.instance.GetEnemigo().restartEnemi(GetNewEnemy());
        GameManager.instance.MostrarCombate(true);
        GameManager.instance.GetEnemigo().UpdateAnim();
        if (!GameManager.instance.mitadDeCamino)
        {
            GameManager.instance.GetAudioManager().PlayBattleMusic();
            StartCoroutine(Wait(0.01f, "fondo")); // fijarse si sirve de algo
        }
        
    }
    public void fondoDecider()
    {
        IdFondo = UnityEngine.Random.Range(0,100);
        if (IdFondo >= 0 && IdFondo < 33)
        {
            IdFondo = 0;
        }
        if (IdFondo >= 33 && IdFondo < 66)
        {
            IdFondo = 1;
        }
        if (IdFondo >= 66)
        {
            IdFondo = 2;
        }
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
        return primerturno;  
    }
    public void Escape()
    {
        float speedEne = GameManager.instance.GetEnemigo().speed;
        float speedJug = GameManager.instance.GetPlayer().speed;
        int eneID = GameManager.instance.GetEnemigo().enemigoID;
        if (speedEne < speedJug & eneID != 8)
        {
            escape = true;
            endCombat(false);
        }
    }
    public void switchAttack(string attack)
    {
        int dado = UnityEngine.Random.Range(1,6);
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        switch (attack)
        {
            case "escape":
                Escape();
                break;
            case "ataqueNormal":
                float daño_f = GameManager.instance.GetPlayer().NormalAttack();
                float dañoFinal_f = daño_f * defensaE / dado;
                GameManager.instance.GetEnemigo().ChangeVida(-dañoFinal_f);
                jugAnim.ultimoDañoJ_ = (int)dañoFinal_f;
                break;
            case "fire":
                    Fire(dado);
                break;
            case "ice":
                    Ice(dado);
                break;            
            case "light":
                    Light(dado);
                break;
        }
        if (GameManager.instance.GetEnemigo().EnemigoVidaActual() <= 0)
        {
            StartCoroutine(Wait(0.767f, "enemigoDead"));
        }
    }



    private void Fire(int dado)
    {
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        float inteligencia = GameManager.instance.GetPlayer().MagicAttack("fire");

        float daño = inteligencia * defensaE/dado;

        GameManager.instance.GetEnemigo().ChangeVida(-daño);
        jugAnim.ultimoDañoJ_ = (int)daño;
        GameManager.instance.GetPlayer().mana -= manaFire;
    }
    private void Ice(int dado)
    {
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        float inteligencia = GameManager.instance.GetPlayer().MagicAttack("ice");

        float daño = inteligencia * defensaE/dado;

        GameManager.instance.GetEnemigo().ChangeVida(-daño);
        GameManager.instance.GetEnemigo().speed /= 2;
        jugAnim.ultimoDañoJ_ = (int)daño;
        GameManager.instance.GetPlayer().mana -= manaIce;
    }
    private void Light(int dado)
    {
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        float inteligencia = GameManager.instance.GetPlayer().MagicAttack("light");

        float daño = inteligencia * defensaE/dado;

        GameManager.instance.GetEnemigo().ChangeVida(-daño*2);
        jugAnim.ultimoDañoJ_ = (int)daño*2;
        GameManager.instance.GetPlayer().mana -= manaLight;
    }



    public void newAtack(string attack)
    {
        GameManager.instance.GetPlayer().RestartIdleAnim();
        atackTipe = attack;
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        GameManager.instance.SetBotonesCombat(false);
        GameManager.instance.GetPlayer().turn = primerTurno();
        if (primerTurno())
        {
            switchAttack(attack);
            if (GameManager.instance.GetEnemigo().EnemigoVidaActual() > 0)
            {
                StartCoroutine(Wait(1.017f, "enemigo"));
                StartCoroutine(Wait(2.017f, "enTurn"));
            };
        }
        else
        {
            if (GameManager.instance.GetEnemigo().EnemigoVidaActual() > 0)
            {
                StartCoroutine(Wait(0.01f, "enemigo"));
                StartCoroutine(Wait(2.017f, "enTurn"));
            }
            StartCoroutine(Wait(1.017f, "player"));
        }
    }
    public IEnumerator Wait(float seconds, string comand)
    {
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
                jugAnim.ultimoDañoE_ = (int)dañofinal_f;
                break;
            case 1:
                float daño_m = GameManager.instance.GetEnemigo().MagicAttackEnem();
                float dañofinal_m = (daño_m * defensaJ);
                GameManager.instance.GetPlayer().ChangeVida(-dañofinal_m);
                jugAnim.ultimoDañoE_ = (int)dañofinal_m;
                break;
            case 2:
                Debug.Log("ERROR RANDOM MUY LARGO");
                break; 
        }
        if (GameManager.instance.GetPlayer().GetVidaActual() <= 0)
            StartCoroutine(Wait(2, "playerDead"));
    }
    public void MitadCamino()
    {
        GameObject pend = GameManager.instance.GetPendiente();
        pendiente pendSc = pend.GetComponent<pendiente>();
        pend.SetActive(true);
        pendSc.StartPendiente();
    }
    public void endCombat(bool win)
    {
        jugAnim.ResetAnimNumeros();
        if(!GameManager.instance.mitadDeCamino)
        GameManager.instance.GetAudioManager().AudioSourceControl(0,false);
        inCombat = false;
        exitAnim = true;
        GameManager.instance.GetFondoAnim().UpdateAnim(-1,exitAnim);
        int eneID = GameManager.instance.GetEnemigo().enemigoID;
        if (win && !escape)
        {
            if(eneID != 8)
            {
                GameManager.instance.changelevel = true;
                GameManager.instance.GetPlayer().ChangeExp(GameManager.instance.GetEnemigo().expEne);
                GameManager.instance.MostrarCombate(false);
            }
            else if (eneID == 8)
            {
                GameManager.instance.GetPlayer().ChangeExp(GameManager.instance.GetEnemigo().expEne);
                GameManager.instance.MostrarCombate(false);
                MitadCamino();
            }
        }
        else if(!escape)
        {
            GameManager.instance.MostrarCombate(false);
            GameManager.instance.EndGame(true);
        }
        else if(escape)
        {
            GameManager.instance.changelevel = true;
            GameManager.instance.MostrarCombate(false);
        }
        GameManager.instance.UI.EndCombat();
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