using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemigos;
    [SerializeField] private List<Transform> puntosRespawn;
    private HandlerGame handlerGame;
    int indexEnemigo;
    int randomPunto;

    void Awake()
    {
        handlerGame = GameObject.Find("HandlerGame").GetComponent<HandlerGame>();
    }
    void Start()
    {
        int random = Random.Range(0, 100);
        randomPunto = Random.Range(0, puntosRespawn.Count);
        if (random <= 10)
        {
            indexEnemigo = 0;
        }
        else if (random > 10 && random <= 50)
        {
            indexEnemigo = 1;
        }
        else if (random > 50 && random <= 100)
        {
            indexEnemigo = 2;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            handlerGame.restarPastel();
            enemigos[indexEnemigo].transform.position = puntosRespawn[randomPunto].position;
            enemigos[indexEnemigo].SetActive(true);
            Destroy(gameObject);
        }
    }

}
