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
            GameManager.instance.sfx.PlayHit();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.instance.GetSpawnOBJ().newSpawn(0,0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.instance.GetSpawnOBJ().newSpawn(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.instance.GetEnemigo().UpdateAnim();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameManager.instance.GetSpawnOBJ().newSpawn(2, 2);
        }

    }
}
