using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public Sprite cofre;
    public Sprite libro;

    private string nameOBJ;

    public void StartOBJ(string _name)
    {
        Debug.Log("spawnOBJ");
        SpriteRenderer ren = GetComponent<SpriteRenderer>();
        nameOBJ = _name;
        switch(nameOBJ)
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
        switch(nameOBJ)
        {
            case "cofre":
                GameManager.instance.GetPlayer().ChangeVida(10);
                break;
            case "libro":
                GameManager.instance.GetPlayer().ChangeExp(30);
                break;
            default:
                Debug.Log("null");
                break;
        }
    }

    private void OnMouseDown()
    {
        OpenOBJ();
        Destroy(gameObject);
    }
}
