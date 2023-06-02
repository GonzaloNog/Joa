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

    public void newCombat()
    {
        inCombat = true;
        GameManager.instance.GetEnemigo().restartEnemi("elfoOscuro");
        this.gameObject.SetActive(true);
    }

    public bool GetinCombat()
    {
        return inCombat;
    }

    public void newAtack(string atack)
    {

    }
}
