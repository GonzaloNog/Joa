using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAnim : MonoBehaviour
{
    public void setBool(string id, bool a)
    {
        this.GetComponent<Animator>().SetBool(id,a);
    }
}
