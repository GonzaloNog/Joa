using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))

        {
            Debug.Log("Tecla A");
            GameManager.instance.MostrarCombate();

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Tecla S- GetPlayer.NormalAttack");
            GameManager.instance.GetEnemigo().ChangeVida(-10);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Tecla D- GetPlayer.MagicAttack");
            GameManager.instance.GetPlayer().MagicAttack();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Tecla Q- GetEnemigo.NormalAttackEnem");
            GameManager.instance.GetEnemigo().NormalAttackEnem();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Tecla W- GetEnemigo.MagicAttackEnem");
            Debug.Log(GameManager.instance.GetEnemigo().MagicAttackEnem());
            GameManager.instance.GetEnemigo().MagicAttackEnem();
        }

    }
}
