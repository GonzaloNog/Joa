using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combate : MonoBehaviour
{
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
    }

    public bool GetinCombat()
    {
        return inCombat;
    }

    public void newAtack(string attack)
    {
        Debug.Log("Entro newAttack");
        float defensaE = DefToDR(GameManager.instance.GetEnemigo().defensaEne);
        switch (attack)
        {
            case "ataqueNormal":
                float daño_f = GameManager.instance.GetPlayer().NormalAttack();
                float dañoFinal_f = (daño_f * defensaE);
                GameManager.instance.GetEnemigo().ChangeVida(-dañoFinal_f);
                Debug.Log("Daño Fis Jug:" + dañoFinal_f);
                break;
            case "ataqueMagico":
                float daño_m = GameManager.instance.GetPlayer().MagicAttack();
                float dañoFinal_m = (daño_m * defensaE);
                GameManager.instance.GetEnemigo().ChangeVida(-dañoFinal_m);
                Debug.Log("Daño Mag Jug:" + dañoFinal_m);
                break;
        }
        if (GameManager.instance.GetEnemigo().EnemigoVidaActual() > 0)
        {
            Debug.Log("newEnemiAttack");
            newEnemiAtack();
        }
        else if (GameManager.instance.GetEnemigo().EnemigoVidaActual() < 0)
            //StartCoroutine(Wait(10));
        endCombat(true);
        /*
                int speedJ = (int)GameManager.instance.GetPlayer().speed;
                int speedE = GameManager.instance.GetEnemigo().GetEnemySpeed();
                if (speedJ > speedE)
                {

                }
                else 
        */


    }
    public IEnumerator Wait(int seconds)
    {
        Debug.Log("Wait");
        yield return new WaitForSeconds(10);
        Debug.Log("Termino Wait");
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
                Debug.Log("Daño Fis Ene: " + dañofinal_f);
                break;
            case 1:
                float daño_m = GameManager.instance.GetEnemigo().MagicAttackEnem();
                float dañofinal_m = (daño_m * defensaJ);
                GameManager.instance.GetPlayer().ChangeVida(-dañofinal_m);
                Debug.Log("Daño Mag Ene: " + dañofinal_m);
                break;
            case 2:
                Debug.Log("ERROR RANDOM MUY LARGO");
                break; 
        }
        Debug.Log("VIDA Actual Jugador: " + GameManager.instance.GetPlayer().GetVidaActual());
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
        //random sin UnityEngine. daba cs0104
        int a = UnityEngine.Random.Range(0, enemigos[GameManager.instance.nivelActual].enemigos.Length);
        return enemigos[GameManager.instance.nivelActual].enemigos[a];
    }
    public float DefToDR(float defense)
    {
        float reduction = 100 / (defense + 100);
        return reduction;
    }
}