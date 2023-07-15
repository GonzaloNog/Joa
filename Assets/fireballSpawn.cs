using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
public class fireballSpawn : MonoBehaviour
{
    public Transform spawn;
    public Transform _target;
    public fireball prefab;
    private fireball temp;
    public void Spawn()
    {
        fireball instance = Instantiate(prefab, spawn.position, spawn.rotation);
        instance.StartFireBall(_target);
        //temp = Instantiate(prefab, spawn.position, spawn.rotation);
        //temp.StartFireBall();
    }
}