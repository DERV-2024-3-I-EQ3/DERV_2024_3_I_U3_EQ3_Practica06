using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float distanciaVisualizacion;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float tiempoDesaparecer;
    [SerializeField] private int dañoAtaque;

    private new Rigidbody rigidbody;
    private Animator animator;
    private Transform ubicacionPedro;
    private Coroutine contadorDesaparecer;

    private HandlerGame handlerGame;
    private HandlerSound handlerSound;

    public bool IsFollowing = false;
    private Coroutine CoroutineAtacar = null;

    private AudioSource sonidoHerir;

    void Awake()
    {
        ubicacionPedro = GameObject.Find("Pedro").transform;
        handlerSound = GameObject.Find("HandlerSound").GetComponent<HandlerSound>();
        handlerGame = GameObject.Find("HandlerGame").GetComponent<HandlerGame>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sonidoHerir = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (handlerGame.IsAlive() && handlerGame.pasteles > 0)
        {
            float distance = Vector3.Distance(ubicacionPedro.position, transform.position);

            if (distance < distanciaVisualizacion && distance > distanciaAtaque)
            {
                IsFollowing = true;
                handlerSound.activarSonidoPersecusion();

                if (contadorDesaparecer != null)
                {
                    StopCoroutine(contadorDesaparecer);
                    contadorDesaparecer = null;
                }


                Vector3 direction = (ubicacionPedro.position - transform.position).normalized;
                direction.y = 0;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3f * Time.deltaTime);
                rigidbody.MovePosition(transform.position + direction * velocidad * Time.deltaTime);

            }
            else if (distance <= distanciaAtaque)
            {
                if (CoroutineAtacar == null)
                {
                    CoroutineAtacar = StartCoroutine(atacar());
                }
            }
            else
            {
                IsFollowing = false;

                if (contadorDesaparecer == null)
                {
                    contadorDesaparecer = StartCoroutine(ContadorAdios());
                }
                handlerSound.desactivarSonidoPersecusion();
            }

            animator.SetBool("IsFollowing", IsFollowing);
        }
        else
        {
            StopCoroutine(atacar());
            animator.SetBool("IsFollowing", false);
        }
    }

    IEnumerator ContadorAdios()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(tiempoDesaparecer);
        gameObject.SetActive(false);
    }

    IEnumerator atacar()
    {
        if (sonidoHerir != null)
        {
            sonidoHerir.PlayOneShot(sonidoHerir.clip);
        }
        int valorRestar = Random.Range(100, dañoAtaque);
        handlerGame.restarVida(valorRestar);
        animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(0.5f);
        CoroutineAtacar = null;
    }

}
