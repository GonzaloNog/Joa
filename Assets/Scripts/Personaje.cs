using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    //Estadisticas
    public float vidaMaxima = 100;
    public float defensa = 90;
    public float inteligencia = 80;
    public float fuerza = 70;
    public float speed = 20;
    public bool live = true;

    //Estadisticas Buff
    private float vidaMaximaBuff = 0;
    private float defensaBuff = 0;
    private float inteligenciaBuff = 0;
    private float fuerzaBuff = 0;
    private float speedBuff = 0;

    //Estadisticas equipo
    private float vidaMaximaEquip = 0;
    private float defensaEquip = 0;
    private float inteligenciaEquip = 0;
    private float fuerzaEquip = 0;
    private float speedEquipo = 0;

    //exp
    private int exp = 0;
    private int nextLevelExp = 100;
    private int level = 0;
    private int puntos = 10;

    //Valores Actuales
    private float vidaActual = 0;
    void Awake()
    {
        vidaActual = vidaMaxima;
    }
    private void Start()
    {
        GameManager.instance.ChangeVidaPLayer();
    }

    public bool ChangeVida(float _changeVida)
    {
        vidaActual = vidaActual + _changeVida;
        GameManager.instance.ChangeVidaPLayer();
        Debug.Log(vidaActual);
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
            return true;
        }
        else if (vidaActual <= 0)
        {
            live = false;
            Debug.Log("Player Muere");
            return false;
        }
        else
            return true;
    }
    public void ChangeExp(int _exp)
    {
        exp += _exp;
        Debug.Log(exp);
        if (exp >= nextLevelExp)
        {
            level++;
            puntos += 5;
            exp -= nextLevelExp;
            nextLevelExp = nextLevelExp * 2;
            Debug.Log("new level " + level);
        }
    }
    public void UsePoints(string estadistica, int cantidad)
    {
        if (cantidad <= puntos)
        {
            puntos -= cantidad;
            switch (estadistica)
            {
                case "vidaMaxima":
                    vidaMaxima = vidaMaxima + (cantidad * 10);
                    vidaActual =  vidaActual + (cantidad * 10);
                    if (vidaActual > vidaMaxima)
                        vidaActual = vidaMaxima;
                    GameManager.instance.ChangeVidaPLayer();
                    Debug.Log("nueva vida maxima: " + vidaMaxima);
                    break;
                case "defensa":
                    defensa = defensa + (cantidad * 10);
                    break;
                case "inteligencia":
                    inteligencia = inteligencia + (cantidad * 10);
                    break;
                case "fuerza":
                    fuerza = fuerza + (cantidad * 10);
                    break;
                case "speed":
                    speed = speed + (cantidad * 10);
                    break;
                default:
                    Debug.Log("Estadistica no encontrada");
                    break;
            }
        }
        else
        {
            Debug.Log("Puntos insuficientes");
        }
    }

    public float NormalAttack()
    {
        return fuerza + fuerzaBuff + fuerzaEquip;
    }
    public float MagicAttack()
    {
        return inteligencia + inteligenciaBuff + inteligenciaEquip;
    }
    public float GetVidaActual()
    {
        return vidaActual;
    }
}