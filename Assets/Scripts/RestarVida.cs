using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestarVida : MonoBehaviour
{
    [SerializeField] HandlerGame handlerGame;
    private bool isRestando = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isRestando)
        {
            StartCoroutine(RestarVidaCadaSegundos());
        }
    }

    IEnumerator RestarVidaCadaSegundos()
    {
        isRestando = true;
        while (true)
        {
            Debug.Log("Restando vida");
            handlerGame.restarVida(100);

            yield return new WaitForSeconds(1f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            isRestando = false;
        }
    }
}
