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

    public void newAtack(string attack)
    {
        switch (attack)
        {
            case "ataqueNormal":
                float da�o_f = (GameManager.instance.GetPlayer().NormalAttack() * -1);
                GameManager.instance.GetEnemigo().ChangeVida(da�o_f);
                Debug.Log("Da�o Fis Jug:" + da�o_f);
            break;
            case "ataqueMagico":
                float da�o_m = (GameManager.instance.GetPlayer().MagicAttack() * -1);
                GameManager.instance.GetEnemigo().ChangeVida(da�o_m);
                Debug.Log("Da�o Mag Jug:" + da�o_m);
                break;
        }
    }
}