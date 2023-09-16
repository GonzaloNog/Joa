using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendiente : MonoBehaviour
{
    public AnimationClip destroyClip;
    public Animator animator;
    private bool destroy;
    private float i;
    public void StartPendiente()
    {
    }
    private void OnMouseDown()
    {
        GameManager.instance.changelevel = true;
        destroy = true;
        animator.SetInteger("animID", 1);
        GameManager.instance.mitadDeCamino = true;
        GameManager.instance.sfx.GetAud().clip = GameManager.instance.sfx.escape;
        GameManager.instance.sfx.GetAud().Play();
        GameManager.instance.camera.GetComponent<cameraScript>().StartAnim();
    }
    private void Update()
    {   
        if(destroy)
        {
            i += Time.deltaTime;
            if (i >= destroyClip.length)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}