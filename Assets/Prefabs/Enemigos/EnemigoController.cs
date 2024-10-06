using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float distanciaVisualizacion;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float tiempoDesaparecer;
    [SerializeField] private float dañoAtaque;


    private new Rigidbody rigidbody;
    private Animator animator;
    private Transform ubicacionPedro;
    private Coroutine contadorDesaparecer;

    public bool IsFollowing = false;
    private bool IsAttacking = false;

    void Awake()
    {
        ubicacionPedro = GameObject.Find("Pedro").transform;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float distance = Vector3.Distance(ubicacionPedro.position, transform.position);
        if (distance < distanciaVisualizacion && distance > distanciaAtaque)
        {
            IsFollowing = true;
            IsAttacking = false;

            if (contadorDesaparecer != null)
            {
                StopCoroutine(contadorDesaparecer);
                contadorDesaparecer = null;
            }

            transform.LookAt(ubicacionPedro);
            float paso = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, ubicacionPedro.position, paso);
        }
        else if (distance <= distanciaAtaque)
        {
            IsAttacking = true;
            // Metodo de quitar vida a Pedro en HandlerGame
        }
        else
        {
            IsAttacking = false;
            IsFollowing = false;
            if (contadorDesaparecer == null)
            {
                contadorDesaparecer = StartCoroutine(ContadorAdios());
            }
        }
        animator.SetBool("IsFollowing", IsFollowing);
        animator.SetBool("IsAttacking", IsAttacking);
    }

    IEnumerator ContadorAdios()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(tiempoDesaparecer);
    }
}
