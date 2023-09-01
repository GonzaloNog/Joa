using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAnim : MonoBehaviour
{
    private Animator anim;
    public void UpdateAnim(bool live, int id)
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("EnemigoID", id);
        anim.SetBool("live", live);
    }
}
