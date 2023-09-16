using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textoNotificacion : MonoBehaviour
{
    private bool textoTimer;
    private float i;

    public Animator anim;
    public AnimationClip clip;
    public GameObject textNotif;

    private void Update()
    {
        if (textoTimer)
        {
            i += Time.deltaTime;
            if (i >= clip.length)
            {
                textoTimer = false;
                i = 0;
                animUpdate(false);
            }
        }
    }
    public void animUpdate(bool a)
    {
        anim.SetBool("texto",a);
    }
    public void SendText(string texto)
    {
        textNotif.GetComponent<TextMeshProUGUI>().text = texto;
        textoTimer = true;
        animUpdate(true);
    }
}
