using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandlerUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI zonaAparicion;
    [SerializeField] public TextMeshProUGUI vida;
    [SerializeField] public TextMeshProUGUI zonaMapa;
    [SerializeField] public TextMeshProUGUI muerto;


    public void cambiarVida(int vida)
    {
        this.vida.text = vida.ToString();
    }

    public void cambiarZona(string zona)
    {
        this.zonaMapa.text = zona;
    }

    public void cambiarZonaAparicion(string zona)
    {
        zonaAparicion.text = zona;
    }

    public void cambiarHazMuerto(string texto)
    {
        muerto.text = texto;
    }
}
