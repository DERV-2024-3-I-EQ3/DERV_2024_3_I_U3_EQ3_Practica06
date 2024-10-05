using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Establecer_ZonaAparicion : MonoBehaviour
{
    [SerializeField] String nombreZona;
    [SerializeField] HandlerGame handlerGame;
    private Transform zonaAparicionTransform;


    void Start()
    {
        zonaAparicionTransform = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Estableciendo zona de aparición en " + nombreZona);
            handlerGame.cambiarZonaAparicionTexto(nombreZona);
            handlerGame.cambiarZonaAparicionTransform(zonaAparicionTransform);
        }
    }
}
