using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj : MonoBehaviour
{
    public Sprite cofre;
    public Sprite libro;
    public Sprite queso;
    private string nameOBJ;
    public GameObject textoObj;
    public TextMeshPro texto;
    bool destroyTimer = false;
    float timer = 0;
    public void StartOBJ(string _name)
    {
        Debug.Log("spawnOBJ");
        SpriteRenderer ren = GetComponent<SpriteRenderer>();
        textoObj.SetActive(false);
        nameOBJ = _name;
        switch(nameOBJ)
        {
            case "cofre":
                ren.sprite = cofre;
                break;
            case "libro":
                ren.sprite = libro;
                break;
            case "queso":
                ren.sprite = queso;
                break;
        }
    }
    public void StartText(string textod)
    {
        Debug.Log("StartText "+ textod);
        textoObj.SetActive(true);
        texto.text = textod;
    }
    public void OpenOBJ()
    {
        switch (nameOBJ)
        {
            case "cofre":
                GameManager.instance.GetPlayer().ChangeVida(10);
                break;
            case "libro":
                GameManager.instance.GetPlayer().ChangeExp(30);
                break;
            case "queso":
                GameManager.instance.GetPlayer().ChangeVida(10);
                break;
            default:
                Debug.Log("null");
                break;
        }
    }
    void Update()
    {
        if (destroyTimer)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                Debug.Log("Destroy");
                Destroy(gameObject);
            }
        }
        else
        {
            timer = 0;
        }
    }
    private void OnMouseDown()
    {
        OpenOBJ();
        StartText("texto de muestra");
        destroyTimer = true;
    }
}
