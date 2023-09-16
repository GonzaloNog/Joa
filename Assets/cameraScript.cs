using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Animator animator;

    public void StartAnim()
    {
        animator.SetInteger("anim",1);
    }
}