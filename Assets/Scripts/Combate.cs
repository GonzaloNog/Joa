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
                float daño_f = (GameManager.instance.GetPlayer().NormalAttack() * -1);
                GameManager.instance.GetEnemigo().ChangeVida(daño_f);
                Debug.Log("Daño Fis Jug:" + daño_f);
            break;
            case "ataqueMagico":
                float daño_m = (GameManager.instance.GetPlayer().MagicAttack() * -1);
                GameManager.instance.GetEnemigo().ChangeVida(daño_m);
                Debug.Log("Daño Mag Jug:" + daño_m);
                break;
        }
    }
}