using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Animator animator;
    [SerializeField] private float velocidad;
    [SerializeField] private float distanciaVisualizacion;

    public bool IsFollowing = false;
    private bool IsAttack = false;

    private Transform ubicacionPedro;

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
        if (distance < distanciaVisualizacion && distance > 0.7f)
        {
            IsFollowing = true;
            IsAttack = false;
            transform.LookAt(ubicacionPedro);
            float paso = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, ubicacionPedro.position, paso);
        }
        else if (distance <= 0.7f)
        {
            IsAttack = true;
        }
        else
        {
            IsAttack = false;
            IsFollowing = false;
        }
        animator.SetBool("IsFollow", IsFollowing);
        animator.SetBool("IsAttack", IsAttack);
    }

}
