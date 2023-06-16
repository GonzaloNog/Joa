using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void UpdateAnim(int animacion)
    {
        anim.SetInteger("Animacion", animacion);
        //anim.SetBool("Estado", estado);
    }
}
