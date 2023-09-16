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
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
    public void Print(string a)
    {
        print(a);
    }
    public void UpdateEst(string plus)
    {
        if(GameManager.instance.GetPlayer().GetPoints() > 0)
        {
            GameManager.instance.GetPlayer().UsePoints(plus, 1);
            SetPlayerEst();
            print(plus);
        }
    }

    public void SetPlayerEst()
    {
        GameManager.instance.UI.UpdatePuntosUI();
    }
}
