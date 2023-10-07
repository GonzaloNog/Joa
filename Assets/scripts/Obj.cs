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
        Personaje jugador = GameManager.instance.GetPlayer();

        float vidaActual_ = jugador.vidaActual;
        float vidaMaxima_ = jugador.vidaMaxima;

        float vidaFaltante = vidaMaxima_-vidaActual_;
        
        float mana_ = jugador.mana;
        float manaMax_ = jugador.manaMax;

        float manaFaltante = manaMax_ - mana_;

        float factor;
        float factorMana;


        switch (nameOBJ)
        {
            case "cofre":
                float randomcofre = Random.value;
                if (randomcofre < 0.5f)
                {
                    factor = -(vidaActual_ / 3);
                    jugador.ChangeVida(factor);
                    string textMalo = "Perdes bastante vida";
                    StartText(textMalo);
                }
                if (randomcofre > 0.5f)
                {
                    factor = (vidaFaltante / 1.5f);
                    factorMana = manaFaltante / 1.5f;
                    jugador.ChangeVida(factor);
                    jugador.mana += (int)factorMana;
                    string textBueno = "Recuperas mucha vida";
                    StartText(textBueno);
                }
                break;

            case "libro":

                factor = jugador.nextLevelExp/1.3f;
                jugador.ChangeExp((int)factor);
                string textLibro = "Ganaste experiencia";
                StartText(textLibro);
                break;

            case "queso":
                factorMana = manaFaltante / 5;
                factor = vidaFaltante / 5;
                jugador.ChangeVida(factor);
                jugador.mana += (int)factorMana;
                string textQueso = "Recuperaste un poco de vida";
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