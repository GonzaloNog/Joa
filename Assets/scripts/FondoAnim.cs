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
        anim.SetInteger("IdFondo", IdFondo);
        anim.SetBool("inCOmbat", exitAnim);
    }
}
