using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuEstadisticas : MonoBehaviour
{
    public TextMeshProUGUI Fuerza;
    public TextMeshProUGUI Vida;
    public TextMeshProUGUI Inteligencia;
    public TextMeshProUGUI Velocidad;
    public TextMeshProUGUI Defensa;
    public TextMeshProUGUI Puntos;
    void Start()
    {
        SetPlayerEst();
    }

    public void Open()
    {
        SetPlayerEst();
    }
    public void UpdateEst(string plus)
    {
        if(GameManager.instance.GetPlayer().GetPoints() > 0)
        {
            GameManager.instance.GetPlayer().UsePoints(plus, 1);
            SetPlayerEst();
        }
    }

    public void SetPlayerEst()
    {
        Fuerza.text = GameManager.instance.GetPlayer().fuerza.ToString();
        Vida.text = GameManager.instance.GetPlayer().vidaMaxima.ToString();
        Inteligencia.text = GameManager.instance.GetPlayer().inteligencia.ToString();
        Velocidad.text = GameManager.instance.GetPlayer().speed.ToString();
        Defensa.text = GameManager.instance.GetPlayer().defensa.ToString();
        Puntos.text = GameManager.instance.GetPlayer().GetPoints().ToString();
    }
}
