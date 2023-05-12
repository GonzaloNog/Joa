using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    //Estadisticas
    public float vidaMaxima = 100;
    public float defensa = 90;
    public float inteligencia = 80;
    public float fuerza = 70;
    public bool live = true;

    //Valores Actuales
    private float vidaActual = 0;
    void Awake()
    {
        vidaActual = vidaMaxima;
    }

    public bool ChangeVida(float _changeVida)
    {
        vidaActual = vidaActual + _changeVida;
        Debug.Log(vidaActual);
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
            return true;
        }
        else if (vidaActual <= 0)
        {
            return false;
        }
        else
            return true;
    }   
}
