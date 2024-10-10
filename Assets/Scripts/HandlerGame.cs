using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerGame : MonoBehaviour
{
    private int vida = 1000;
    public int pasteles = 15;
    [SerializeField] public HandlerUI handlerUI;
    [SerializeField] public Pedro_Movimiento movimientoPersonaje;


    void Start()
    {
        handlerUI.cambiarVida(vida);
        handlerUI.cambiarPasteles(pasteles);
    }
    void Update()
    {
        if (this.vida <= 0)
        {
            handlerUI.cambiarVida(0);
            movimientoPersonaje.matarPedro();
            handlerUI.cambiarTextoFinal("HAZ MUERTO");
        }

        if (this.pasteles <= 0)
        {
            handlerUI.cambiarTextoFinal("GANASTE");
        }
    }

    public bool IsAlive()
    {
        return movimientoPersonaje.IsAlive;
    }

    public void restarPastel()
    {
        this.pasteles--;
        handlerUI.cambiarPasteles(this.pasteles);
    }

    public void restarVida(int vida)
    {
        this.vida -= vida;
        handlerUI.cambiarVida(this.vida);
    }




}
