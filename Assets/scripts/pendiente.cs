using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendiente : MonoBehaviour
{
    public AnimationClip destroyClip;
    public Animator animator;
    private bool tembleque;
    private bool preTimerUI;
    private float i;
    bool ding = false;
    
    public void StartPendiente()
    {
    }
    private void OnMouseDown()
    {
        if(!ding)
        {
            GameManager.instance.GetAudioManager().PlayDing();
            ding = true;
            tembleque = true;
            GameManager.instance.GetAudioManager().AudioSourceControl(2,false);
            animator.SetInteger("animID", 1);
            GameManager.instance.camera.GetComponent<cameraScript>().StartAnim();
        }

    }
    private void Update()
    {   
        if (tembleque) Tembleque();
        if (preTimerUI) TimerPreTimerUI();
    } 
    private void Tembleque()
    {
        i += Time.deltaTime;
        if (i >= destroyClip.length)
        {
            i = 0;
            tembleque = false;
            preTimerUI = true;
        }
    }
    private void TimerPreTimerUI()
    {
        i += Time.deltaTime;
        if (i >= (1.5f-destroyClip.length))
        {
            i = 0;
            DestroyFunc();
        }

    }
    private void DestroyFunc()
    {
        GameManager.instance.mitadDeCamino = true;
        GameManager.instance.changelevel = true;
        this.gameObject.SetActive(false);
        GameManager.instance.GetAudioManager().PlayEscape();
    }
}