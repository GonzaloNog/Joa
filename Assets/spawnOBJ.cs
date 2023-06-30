using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnOBJ : MonoBehaviour
{
    public Transform[] points;
    public string[] prefads;
    public Obj prefad;

    public void newSpawn(int point, int obj)
    {
        if(point < points.Length)
        {
            Obj temp = Instantiate(prefad, points[point].position, points[point].rotation);
            temp.StartOBJ(prefads[obj]);
        }
    }
}
