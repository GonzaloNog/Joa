using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public string enemigo;

    private float vidaEne = 0;
    private float defensaEne = 0;
    private float inteligenciaEne = 0;
    private float fuerzaEne = 0;
    private float expEne = 0;
    private float vidaActual = 0;

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
                    break;
            case "elfoOscuro":
                    vidaEne = 200;
                    defensaEne = 15;
                    inteligenciaEne = 100;
                    fuerzaEne = 50;
                    expEne = 100;
                    break;
            case "minotauro":
                    vidaEne = 300;
                    defensaEne = 23;
                    inteligenciaEne = 50;
                    fuerzaEne = 75;
                    expEne = 150;
                    break;
            case "gargola":
                    vidaEne = 400;
                    defensaEne = 35;
                    inteligenciaEne = 10;
                    fuerzaEne = 100;
                    expEne = 200;
                    break;
            default:
                    Debug.Log("no se encuentra el enemigo");
                break;
        }
        vidaActual = vidaEne;
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
    }
}
