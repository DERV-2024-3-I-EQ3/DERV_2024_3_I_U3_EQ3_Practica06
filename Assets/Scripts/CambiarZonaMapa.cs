using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarZonaMapa : MonoBehaviour
{
    [SerializeField] HandlerGame handlerGame;
    [SerializeField] string nombreZona;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Cambiando a zona " + nombreZona);
            handlerGame.cambiarZonaMapa(nombreZona);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Saliendo de zona " + nombreZona);
            handlerGame.cambiarZonaMapa("Exterior");
        }
    }
}
