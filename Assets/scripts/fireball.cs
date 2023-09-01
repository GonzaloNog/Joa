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
        anim.SetBool("fire",true);
        StartCoroutine(Wait(0.1f,"fire"));
    }
    public void Ice()
    {
        StartCoroutine(Wait(0.1f,"ice"));
    }
    public void Light()
    {

        StartCoroutine(Wait(0.1f, "light"));
    }


    public IEnumerator Wait(float seconds,string spell)
    {
        yield return new WaitForSeconds(seconds);
        switch (spell)
        {
            case "fire":
                anim.SetBool("fire", false);
                break;
            case"ice":
                anim.SetBool("ice", false);
                break;
            case "light":
                anim.SetBool("light", false);
                break;

        }
        
    }
}
