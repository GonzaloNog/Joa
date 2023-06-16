using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //esto
    public Sprite[] fondo;
    //esto
    private SpriteRenderer rend;
    private int idBackground = 0;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        CambiarFondo();
    }
    
    public void CambiarFondo()
    {
        GetComponent<SpriteRenderer>().sprite = fondo[idBackground];
    }

    public int getIdBackground()
    {
        return idBackground;
    }
    public void setIdBackground(int a)
    {
        if(a < fondo.Length)
            idBackground = a;
    }
    public int cantBackgrounds()
    {
        return fondo.Length;
    }

    public void ChangeColor(string colorName)
    {
        switch (colorName)
        {
            case "yellow":
                rend.color = Color.yellow;
                break;
            case "blue":
                rend.color = Color.blue;
                break;
            case "red":
                rend.color = Color.red;
                break;
            default:
                Debug.Log("Color no encontrado");
                break;
        }
    }
}
