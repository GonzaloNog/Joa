using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public Sprite cofre;
    public Sprite libro;

    private SpriteRenderer ren;
    private string nameOBJ;
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
    }
    public void StartOBJ(string _name)
    {
        nameOBJ = _name;
        switch (name)
        {
            case "cofre":
                ren.sprite = cofre;
                break;
            case "libro":
                ren.sprite = libro;
                break;
        }
    }
    public void OpenOBJ()
    {

    }
}
