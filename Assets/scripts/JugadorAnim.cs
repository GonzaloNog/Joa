using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JugadorAnim : MonoBehaviour
{
    private Animator anim;
    private Animator animNumerosJ;
    private Animator animNumerosE;
    private int idle = -1;
    private float time = 32;
    public int ultimoDañoJ_;
    public int ultimoDañoE_;
    public TextMeshProUGUI dañoNumerosJug;
    public TextMeshProUGUI dañoNumerosEne;
    public bool animApagarE;
    public bool animApagarJ;
    private float i;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //timer IDLE 2
        time -= Time.deltaTime;
        if(time <= 0)
        {
            if (idle == -1)
                idle = 2;
            else if (idle == 2)
                idle = -1;
            UpdateAnim(idle);
            time = 32;
        }

        //Timers Numeros Daño
        if(animApagarJ)
        {
            i += Time.deltaTime;
            if (i>=1.5f)
            {
                i = 0;
                dañoNumerosJug.alpha = 0;
                animNumerosJ.SetBool("a",false);
                animApagarJ = false;
            }
        }
        if(animApagarE)
        {
            i += Time.deltaTime;
            if (i>=1.5f)
            {
                i = 0;
                dañoNumerosEne.alpha = 0;
                animNumerosE.SetBool("a",false);
                animApagarE = false;
            }
        }

    }
    public void PlayHit(string a)
    {
        print("JugadorAnim.cs: PlayHit()");
        GameManager.instance.GetAudioManager().PlayHit();
        switch(a)
        {
            //GolpeRecibido
            case "j":
            print("ultimoDañoE_:" + ultimoDañoE_);
            dañoNumerosEne.text = ultimoDañoE_.ToString();
            dañoNumerosJug.alpha = 1;
            break;
            //Ataque
            case "e":
            print("ultimoDañoJ_:" + ultimoDañoJ_);
            dañoNumerosJug.text = ultimoDañoJ_.ToString();
            dañoNumerosEne.alpha = 1;
            break;
            default:
            break;
        }
        StartAnim(a);
    }  
    private void StartAnim(string a)
    {
        switch(a)
        {
            case "j":
            animNumerosJ = dañoNumerosJug.GetComponent<Animator>();
            animApagarJ = true;
            animNumerosJ.SetBool("a",true);
            break;
            case "e":
            animNumerosE = dañoNumerosEne.GetComponent<Animator>();
            animApagarE = true;
            animNumerosE.SetBool("a",true);
            break;
            default:
            break;
        }
    }
    public void UpdateAnim(int animacion)
    {
        anim.SetInteger("Animacion", animacion);
        //anim.SetBool("Estado", estado);
    }
    public void RestartTimeIdle()
    {
        time = 32;
        idle = -1;
        UpdateAnim(idle);
    }
}
