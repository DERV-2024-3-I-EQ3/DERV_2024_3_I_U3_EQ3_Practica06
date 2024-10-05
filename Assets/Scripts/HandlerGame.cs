using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerGame : MonoBehaviour
{
    private int vida = 1000;
    private string zonaMapa = "Exterior";
    private string zonaAparicionTexto = "Origen";
    public Transform zonaAparicionTransform;
    [SerializeField] public GameObject personaje;

    [SerializeField] public HandlerUI handlerUI;
    [SerializeField] public Pedro_Movimiento movimientoPersonaje;
    void Start()
    {
        zonaAparicionTransform = transform;
        handlerUI.cambiarVida(vida);
        handlerUI.cambiarZona(zonaMapa);
        handlerUI.cambiarZonaAparicion(zonaAparicionTexto);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            vida = 1000;
            personaje.GetComponent<Transform>().position = zonaAparicionTransform.position;
            handlerUI.cambiarVida(vida);
            movimientoPersonaje.revivirPedro();
            handlerUI.cambiarHazMuerto("");
        }
    }

    public void restarVida(int vida)
    {
        if (this.vida > 0)
        {
            this.vida -= vida;
            handlerUI.cambiarVida(this.vida);
        }
        else if (this.vida <= 0)
        {
            handlerUI.cambiarVida(0);
            movimientoPersonaje.matarPedro();
            handlerUI.cambiarHazMuerto("HAZ MUERTO");
        }
    }

    public void regenerarVida(int vida)
    {
        if (this.vida < 1000)
        {
            this.vida += vida;
            handlerUI.cambiarVida(this.vida);
        }
    }

    public void cambiarZonaMapa(string zona)
    {
        this.zonaMapa = zona;
        handlerUI.cambiarZona(zona);
    }

    public void cambiarZonaAparicionTexto(string zona)
    {
        this.zonaAparicionTexto = zona;
        handlerUI.cambiarZonaAparicion(zona);
    }

    public void cambiarZonaAparicionTransform(Transform zona)
    {
        this.zonaAparicionTransform = zona;
    }


}
