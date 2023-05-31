using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    private bool inCombat = false;   
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(inCombat)
        {

        }
    }

    public void newCombat()
    {
        GameManager.instance.GetEnemigo().restartEnemi("duende");
        inCombat = true;
        this.gameObject.SetActive(true);
    }
}
