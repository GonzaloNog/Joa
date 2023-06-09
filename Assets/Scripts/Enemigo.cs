using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public EnemiAnim anim;
    public float vidaEne = 0;
    public float defensaEne = 0;
    public float inteligenciaEne = 0;
    public float fuerzaEne = 0;
    public int expEne = 0;
    public string nameEne = "null";
    private float vidaActual = 0;
    public int speed = 0;

    private int enemigoID = 0;
    private bool live = false;

    public void EstadisticasEnem(string enemigo)
    {
        switch (enemigo)
        {
            case "slime":
                vidaEne = 10;
                defensaEne = 5;
                inteligenciaEne = 5;
                fuerzaEne = 10;
                speed = 20;
                expEne = 50;
                nameEne = "slime";
                enemigoID = 0;
                break;
            case "rat":
                vidaEne = 15;
                defensaEne = 7;
                inteligenciaEne = 7;
                fuerzaEne = 20;
                speed = 20;
                expEne = 100;
                nameEne = "rat";
                enemigoID = 1;
                break;
            case "worm":
                vidaEne = 22;
                defensaEne = 11;
                inteligenciaEne = 13;
                fuerzaEne = 25;
                speed = 25;
                expEne = 150;
                nameEne = "worm";
                enemigoID = 2;
                break;
            case "boneworm":
                vidaEne = 34;
                defensaEne = 16;
                inteligenciaEne = 15;
                fuerzaEne = 30;
                speed = 0;
                expEne = 200;
                nameEne = "boneworm";
                enemigoID = 3;
                break;
            case "wolf":
                vidaEne = 50;
                defensaEne = 20;
                inteligenciaEne = 20;
                fuerzaEne = 35;
                speed = 30;
                expEne = 250;
                nameEne = "wolf";
                enemigoID = 4;
                break;
            case "spider":
                vidaEne = 75;
                defensaEne = 26;
                inteligenciaEne = 23;
                fuerzaEne = 40;
                speed = 20;
                expEne = 300;
                nameEne = "spider";
                enemigoID = 5;
                break;
            case "scorpion":
                vidaEne = 113;
                defensaEne = 33;
                inteligenciaEne = 27;
                fuerzaEne = 45;
                speed = 20;
                expEne = 350;
                nameEne = "scorpion";
                enemigoID = 6;
                break;
            case "cerberus":
                vidaEne = 170;
                defensaEne = 56;
                inteligenciaEne = 40;
                fuerzaEne = 25;
                speed = 40;
                expEne = 400;
                nameEne = "cerberus";
                enemigoID = 7;
                break;
            case "boss":
                vidaEne = 256;
                defensaEne = 57;
                inteligenciaEne = 100;
                fuerzaEne = 20;
                speed = 50;
                expEne = 1000;
                nameEne = "boss";
                enemigoID = 8;
                break;


            default:
                    Debug.Log("no se encuentra el enemigo");
                break;
        }
        vidaActual = vidaEne;
        GameManager.instance.ChangeVidaEnemigo();
    }
    public int GetEnemySpeed()
    {
        return speed;
    }
    public bool ChangeVida(float _changeVida)
    {
        vidaActual = vidaActual + _changeVida;
        GameManager.instance.ChangeVidaEnemigo();
        //Debug.Log("vida actual enemigo:"+vidaActual);
        if (vidaActual > vidaEne)
        {
            vidaActual = vidaEne;
            return true;
        }
        else if (vidaActual <= 0)
        {
            live = false;
            UpdateAnim();
            //ebug.Log("Enemigo Muere");
            return false;
        }
        else
            return true;
    }
    public float NormalAttackEnem()
    {
        return fuerzaEne;
    }
    public float MagicAttackEnem()
    {
        return inteligenciaEne;
    }
    public void restartEnemi(string nuevoEnemigo)
    {
        EstadisticasEnem(nuevoEnemigo);
        live = true;
    }
    public float EnemigoVidaActual()
    {
        return vidaActual;
    }
    public void UpdateAnim()
    {
        anim.UpdateAnim(live, enemigoID);
    }
}