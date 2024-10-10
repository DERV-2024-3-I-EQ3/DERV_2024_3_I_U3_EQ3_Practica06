using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedro_Movimiento : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Animator animator;
    private AudioSource pasos;
    [SerializeField] private float velocidad = 3f;
    [SerializeField] private int fuerzaSalto = 2;
    [SerializeField] private float delay = 1f;
    [SerializeField] private HandlerGame handlerGame;

    public bool IsJumping = false;
    public bool IsAlive = true;
    private bool IsWalking = false;
    private Coroutine sonidoCoroutine = null;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        pasos = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsAlive && handlerGame.pasteles > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)
            {
                rigidbody.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                IsJumping = true;
            }
            animator.SetBool("IsJumping", IsJumping);

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 velocity = Vector3.zero;

            if (hor != 0 || ver != 0)
            {
                Vector3 movimiento = (transform.right * hor + transform.forward * ver).normalized;
                velocity = movimiento * velocidad;
                IsWalking = true;
                animator.SetBool("IsWalking", IsWalking);
            }
            else
            {
                IsWalking = false;
                animator.SetBool("IsWalking", IsWalking);
            }

            velocity.y = rigidbody.velocity.y;
            rigidbody.velocity = velocity;

            if (IsWalking && (sonidoCoroutine == null))
            {
                sonidoCoroutine = StartCoroutine(ControlarSonidoPasos());
            }
            else if (!IsWalking && pasos.isPlaying)
            {
                sonidoCoroutine = null;
            }
        }
        else
        {
            IsWalking = false;
        }
    }

    private IEnumerator ControlarSonidoPasos()
    {
        while (IsWalking)
        {
            pasos.Play();
            yield return new WaitForSeconds(delay);
        }
        sonidoCoroutine = null;
        pasos.Stop();
    }

    void OnCollisionEnter(Collision collision)
    {
        IsJumping = false;
    }

    public void matarPedro()
    {
        animator.SetBool("IsDeath", true);
        IsAlive = false;
    }

    public void revivirPedro()
    {
        animator.SetBool("IsDeath", false);
        IsAlive = true;
    }
}
