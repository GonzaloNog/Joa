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

    private bool destroyTimer = false;
    private float timer = 0;
    private bool efect = true;

    public void StartOBJ(string _name)
    {
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
        float vidaActual_ = GameManager.instance.GetPlayer().vidaActual;
        float vidaMaxima_ = GameManager.instance.GetPlayer().vidaMaxima;
        float vidaFaltante = vidaMaxima_-vidaActual_;
        switch (nameOBJ)
        {
            case "cofre":
                int randomcofre = Random.Range(0,1);
                if (randomcofre == 0)
                {
                    GameManager.instance.GetPlayer().ChangeVida(-(vidaFaltante/10));
                }
                else
                {
                GameManager.instance.GetPlayer().ChangeVida((vidaFaltante/5));
                StartText("Ganaste 10 de vida");
                }
                break;
            case "libro":
                GameManager.instance.GetPlayer().ChangeExp(GameManager.instance.GetPlayer().nextLevelExp);
                break;
            case "queso":
                GameManager.instance.GetPlayer().ChangeVida(vidaFaltante/10);
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
            print("timer" + timer);
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
        print("OnMouseDown");
        if (efect && GameManager.instance.changelevel)
        {
            OpenOBJ();
            destroyTimer = true;
            efect = false;
        }
    }
}
