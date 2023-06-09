using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public string enemigo;

    public float vidaEne = 0;
    public float defensaEne = 0;
    public float inteligenciaEne = 0;
    public float fuerzaEne = 0;
    public int expEne = 0;
    public string nameEne = "null";
    private float vidaActual = 0;
    private int enemigoID = 0;

    private bool live = false;
    private void Start()
    {
        EstadisticasEnem(enemigo);
    }
    public void EstadisticasEnem(string enemigo)
    {
        switch (enemigo)
        {
            case "duende":
                    vidaEne = 100;
                    defensaEne = 10;
                    inteligenciaEne = 20;
                    fuerzaEne = 25;
                    expEne = 50;
                    nameEne = "duende";
                    enemigoID = 0;
                break;
            case "elfoOscuro":
                    vidaEne = 200;
                    defensaEne = 15;
                    inteligenciaEne = 100;
                    fuerzaEne = 50;
                    expEne = 100;
                    nameEne = "Elfo Oscuro";
                    enemigoID = 1;
                break;
            case "minotauro":
                    vidaEne = 300;
                    defensaEne = 23;
                    inteligenciaEne = 50;
                    fuerzaEne = 75;
                    expEne = 150;
                    nameEne = "minotauro";
                break;
            case "gargola":
                    vidaEne = 400;
                    defensaEne = 35;
                    inteligenciaEne = 10;
                    fuerzaEne = 100;
                    expEne = 200;
                    nameEne = "gargola";
                break;
            default:
                    Debug.Log("no se encuentra el enemigo");
                break;
        }
        vidaActual = vidaEne;
        GameManager.instance.ChangeVidaEnemigo();
    }
    public bool ChangeVida(float _changeVida)
    {
        vidaActual = vidaActual + _changeVida;
        GameManager.instance.ChangeVidaEnemigo();
        Debug.Log("vida actual enemigo:"+vidaActual);
        if (vidaActual > vidaEne)
        {
            vidaActual = vidaEne;
            return true;
        }
        else if (vidaActual <= 0)
        {
            live = false;
            Debug.Log("Enemigo Muere");
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
}