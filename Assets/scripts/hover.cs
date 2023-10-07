using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class hover : MonoBehaviour
{
    public GameObject target;
    public void HoverStart(GameObject target_)
    {
        target = target_;
    }
    public void Update()
    {
        this.transform.position = Input.mousePosition;
    }
}