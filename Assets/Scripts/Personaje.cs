using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public JugadorAnim anim;
    //Estadisticas
    public float vidaMaxima = 300;
    public float defensa = 90;
    public float inteligencia = 220;
    public float fuerza = 170;
    public float speed = 20;
    public bool live = true;

    //ataque = 0
    //golpe recibido = 1
    //idle 2 = 2
    int animacion = 0;

    /*Estadisticas Buff
    private float vidaMaximaBuff = 0;
    private float defensaBuff = 0;
    private float speedBuff = 0;

    //Estadisticas equipo
    private float vidaMaximaEquip = 0;
    private float defensaEquip = 0;
    private float speedEquipo = 0;*/

    private float inteligenciaBuff = 0;
    private float fuerzaBuff = 0;
    private float inteligenciaEquip = 0;
    private float fuerzaEquip = 0;

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
        Debug.Log("vidaActualJugador"+vidaActual);
        if (_changeVida < 0)
        {
            animacion = 1;
            StartCoroutine(AnimatorChange(2));
        }
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
        Debug.Log("nueva exp: " + exp);
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
        animacion = 0;
        StartCoroutine(AnimatorChange(1));
        return fuerza + fuerzaBuff + fuerzaEquip;
    }
    public float MagicAttack()
    {
        animacion = 0;
        StartCoroutine(AnimatorChange(1));
        return inteligencia + inteligenciaBuff + inteligenciaEquip;
    }
    public float GetVidaActual()
    {
        return vidaActual;
    }
    public void UpdateAnim()
    {
        anim.UpdateAnim(animacion);
    }
    public IEnumerator AnimatorChange(int seconds)
    {
        UpdateAnim();
        yield return new WaitForSeconds(seconds);
        animacion = -1;
        UpdateAnim();
    }
}