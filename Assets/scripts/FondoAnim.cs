using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void UpdateAnim(int IdFondo, bool exitAnim)
    {
        if (anim != null)
        {
            anim.SetInteger("IdFondo", IdFondo);
            anim.SetBool("exitAnim", exitAnim);
        }
    }
}