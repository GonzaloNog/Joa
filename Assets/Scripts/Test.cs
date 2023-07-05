//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.instance.GetCombate().newCombat();
            //Debug.Log("Tecla A");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.instance.GetSpawnOBJ().newSpawn(0,0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Tecla D- GetPlayer.MagicAttack");
            GameManager.instance.GetSpawnOBJ().newSpawn(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("Tecla Q- GetEnemigo.NormalAttackEnem");
            GameManager.instance.GetEnemigo().UpdateAnim();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("Tecla W- GetEnemigo.MagicAttackEnem");
            //Debug.Log(GameManager.instance.GetEnemigo().MagicAttackEnem());
            GameManager.instance.GetEnemigo().MagicAttackEnem();
        }

    }
}
