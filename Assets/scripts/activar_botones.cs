using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class activar_botones : MonoBehaviour
{
    public GameObject barracombate;

    public void ActivarBotones(bool asd)
    {
        barracombate.SetActive(asd);
    }
}
