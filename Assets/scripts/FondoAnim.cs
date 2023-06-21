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
            Debug.Log("UpdateAnim FondoAnim IdFondo: "+anim.GetInteger("IdFondo"));
            anim.SetInteger("IdFondo", IdFondo);
            anim.SetBool("exitAnim", exitAnim);
        }
        else
            Debug.Log("animeitor nulo");
    }
}