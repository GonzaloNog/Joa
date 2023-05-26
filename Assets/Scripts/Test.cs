using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Tecla A precionada");
            GameManager.instance.GetPlayer().UsePoints("vidaMaxima",5);
        }
    }
}
