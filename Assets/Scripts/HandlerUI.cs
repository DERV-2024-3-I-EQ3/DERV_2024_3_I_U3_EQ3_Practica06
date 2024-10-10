using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandlerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI vida;
    [SerializeField] private TextMeshProUGUI textoFinal;
    [SerializeField] private TextMeshProUGUI pasteles;


    public void cambiarVida(int vida)
    {
        this.vida.text = vida.ToString();
    }

    public void cambiarTextoFinal(string texto)
    {
        textoFinal.text = texto;
    }

    public void cambiarPasteles(int pasteles)
    {
        this.pasteles.text = pasteles.ToString();
    }
}
