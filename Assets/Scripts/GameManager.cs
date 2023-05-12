using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Personaje player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    public void CheckGameManager()
    {
        Debug.Log("GameManager is ready");
    }
    public void ChangeLifePlayer(float num)
    {
        player.ChangeVida(num);
    }
}
