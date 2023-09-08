using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public JugadorAnim anim;
    private AudioSource aud;
    public float vidaMaxima = 70;
    public float defensa = 10;
    public float inteligencia = 50;
    public float fuerza = 50;
    public float speed = 10;
    public bool live = true;
    public bool turn = false;
    public float[] speall;
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
    private int exp = 0;
    public int nextLevelExp = 100;
    private int level = 0;
    private int puntos = 10;

    public float vidaActual = 0;

    //spell
    public fireball spe;
    void Awake()
    {
        vidaActual = vidaMaxima;
    }
    private void Start()
    {
        GameManager.instance.ChangeVidaPLayer();
        aud = GetComponent<AudioSource>();
    }

    public bool ChangeVida(float _changeVida)
    {
        vidaActual = vidaActual + _changeVida;
        GameManager.instance.ChangeVidaPLayer();
        if (_changeVida < 0)
        {
            animacion = 1;
            if (turn)
                StartCoroutine(AnimatorChange(1.017f, true));
            else
                StartCoroutine(AnimatorChange(1.017f, false));
        }
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
            return true;
        }
        else if (vidaActual <= 0)
        {
            live = false;
            return false;
        }
        else
            return true;
    }
    public void ChangeExp(int _exp)
    {
        exp += _exp;
        if (exp >= nextLevelExp)
        {
            level++;
            puntos += 5;
            exp -= nextLevelExp;
            nextLevelExp = nextLevelExp +200;
            GameManager.instance.UI.UpdatePuntosUI();
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
                    break;
                case "defensa":
                    defensa = defensa + (cantidad * 10);
                    break;
                case "inteligencia":
                    inteligencia = inteligencia + (cantidad * 3);
                    break;
                case "fuerza":
                    fuerza = fuerza + (cantidad * 3);
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
        }
    }
    public float NormalAttack()
    {
        aud.clip = GameManager.instance.GetAudioManager().GetEfectSound("shoot");
        aud.Play();
        animacion = 0;
        if(turn)
            StartCoroutine(AnimatorChange(0.867f, false));
        else
            StartCoroutine(AnimatorChange(0.867f, true));
        return fuerza + fuerzaBuff + fuerzaEquip;
    }
    public float MagicAttack(string speall)
    {
        switch (speall)
        {
            case "fire":
                spe.Fireball();
                break;
            case"ice":
                spe.Ice();
                break;
            case"light":
                spe.Light();
                break;
            default:
                Debug.Log("Magia no registrada");
                break;
        }
        animacion = 0;
        if (turn)
            StartCoroutine(AnimatorChange(0.867f, false));
        else
            StartCoroutine(AnimatorChange(0.867f, true));
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
    public void RestartIdleAnim()
    {
        anim.RestartTimeIdle();
    }
    public IEnumerator AnimatorChange(double seconds, bool idle)
    {
        UpdateAnim();
        float seconds2 = (float) seconds;
        yield return new WaitForSeconds(seconds2);
        if (idle)
        {
            animacion = -1;
            UpdateAnim();
        }
    }

    public int GetPoints()
    {
        return puntos;
    }
}