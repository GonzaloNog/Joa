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
    private Animator anim;

    private bool destroyTimer = false;
    private float timer = 0;
    private bool efect = true;

    public AnimationClip clip;
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
        anim = this.GetComponent<Animator>();
        anim.SetBool("destroy",true);
        textoObj.SetActive(true);
        texto.text = textod;

    }
    public void OpenOBJ()
    {
        float vidaActual_ = GameManager.instance.GetPlayer().vidaActual;
        float vidaMaxima_ = GameManager.instance.GetPlayer().vidaMaxima;

        float vidaFaltante = vidaMaxima_-vidaActual_;

        float factor;


        switch (nameOBJ)
        {
            case "cofre":
                float randomcofre = Random.value;
                if (randomcofre < 0.5f)
                {
                    factor = -(vidaActual_ / 3);
                    GameManager.instance.GetPlayer().ChangeVida(factor);
                    string textMalo = "Perdes " + Texto(factor) + " de vida";
                    StartText(textMalo);
                }
                if (randomcofre > 0.5f)
                {
                    factor = (vidaFaltante / 1.5f);
                    GameManager.instance.GetPlayer().ChangeVida(factor);
                    string textBueno = "Recuperas " + Texto(factor) + " puntos de vida";
                    StartText(textBueno);
                }
                break;

            case "libro":

                factor = GameManager.instance.GetPlayer().nextLevelExp;
                GameManager.instance.GetPlayer().ChangeExp((int)factor);
                string textLibro = "Ganas " + Texto(factor) + " puntos de experiencia";
                StartText(textLibro);
                break;

            case "queso":

                factor = vidaFaltante / 10;
                GameManager.instance.GetPlayer().ChangeVida(factor);
                string textQueso = "Recuperas " + Texto(factor) + " puntos de vida";
                StartText(textQueso);
                break;
        }
    }
    private string Texto(float factor)
    {
        if (factor<0)
        {
            factor *= -1;
        }
        int a = (int)factor;
        string b = a.ToString();
        string floatToString = b;
        return floatToString;
    }
    void Update()
    {
        if (destroyTimer)
        {
            timer += Time.deltaTime;
            if (timer >= clip.length)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnMouseDown()
    {
        if (efect && GameManager.instance.changelevel)
        {
            OpenOBJ();
            destroyTimer = true;
            efect = false;
        }
    }
}