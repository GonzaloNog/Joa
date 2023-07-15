using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fireball : MonoBehaviour
{
  
    private Animator anim;
    public void Start()
    {
        anim = GetComponent<Animator>();
        Fireball();
    }
    public void Fireball()
    {
        anim.SetBool("boom",true);
        StartCoroutine(Wait(0.1f));
    }
    public void WaterBall()
    {

        StartCoroutine(Wait(0.1f));
    }


    public IEnumerator Wait(float seconds)
    {
        //Debug.Log("Wait");
        yield return new WaitForSeconds(seconds);
        anim.SetBool("boom", false);
    }
}
