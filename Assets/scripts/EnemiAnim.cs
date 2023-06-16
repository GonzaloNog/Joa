using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void UpdateAnim(bool live, int id)
    {
        anim.SetInteger("EnemigoID", id);
        anim.SetBool("live", live);
    }
}
