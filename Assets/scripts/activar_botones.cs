using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class activar_botones : MonoBehaviour
{
    public GameObject barracombate;

    public void ActivarBotones(bool asd)
    {
        Debug.Log("Entro ActivarBotones");
        barracombate.SetActive(asd);
    }
}
