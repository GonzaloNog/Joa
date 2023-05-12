using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Sprite[] fondo;
    private SpriteRenderer rend;
    private int idBackground = 0;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        //Debug.Log("" + idBackground);
        //Debug.LogError("Error carga iamgen") ;
        //Debug.LogWarning("Se cargo mal");
        

    }
    void Start()
    {
        CambiarFondo();
        GameManager.instance.CheckGameManager();
        GameManager.instance.ChangeLifePlayer(-30);
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
        idBackground = a;
    }
}
