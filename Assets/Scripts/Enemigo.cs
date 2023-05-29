using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vidaEne = 0;
    public int defensaEne = 0;
    public int inteligenciaEne = 0;
    public int fuerzaEne = 0;
    public int expEne = 0;

    public void EstadisticasEnem(string enemigo)
    {
        switch (enemigo)
        {
            case "duende":
                {
                    int vidaEne = 100;
                    int defensaEne = 10;
                    int inteligenciaEne = 20;
                    int fuerzaEne = 25;
                    int expEne = 50;

                    break;
                }
            case "elfoOscuro":
                {
                    int vidaEne = 200;
                    int defensaEne = 15;
                    int inteligenciaEne = 100;
                    int fuerzaEne = 50;
                    int expEne = 100;

                    break;
                }
            case "minotauro":
                {
                    int vidaEne = 300;
                    int defensaEne = 23;
                    int inteligenciaEne = 50;
                    int fuerzaEne = 75;
                    int expEne = 150;

                    break;
                }
            case "gargola":
                {
                    int vidaEne = 400;
                    int defensaEne = 35;
                    int inteligenciaEne = 10;
                    int fuerzaEne = 100;
                    int expEne = 200;

                    break;
                }
            default:
                {
                    Debug.Log("no se encuentra el enemigo");
                    break;
                }
        }
    }
    public int NormalAttackEnem()
    {
        return fuerzaEne;
    }
    public int MagicAttackEnem()
    {
        return inteligenciaEne;
    }
}
