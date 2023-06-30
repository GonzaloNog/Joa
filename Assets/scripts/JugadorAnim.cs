using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAnim : MonoBehaviour
{
    private Animator anim;
    private int idle = -1;
    private float time = 8;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            if (idle == -1)
                idle = 2;
            else if (idle == 2)
                idle = -1;
            UpdateAnim(idle);
            time = 8;
        }
    }
    public void UpdateAnim(int animacion)
    {
        anim.SetInteger("Animacion", animacion);
        //anim.SetBool("Estado", estado);
    }
    public void RestartTimeIdle()
    {
        time = 8;
        idle = -1;
        UpdateAnim(idle);
    }
}
