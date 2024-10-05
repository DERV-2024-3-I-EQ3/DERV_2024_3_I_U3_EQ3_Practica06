using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RegenerarVida : MonoBehaviour
{
    [SerializeField] HandlerGame handlerGame;
    private bool isRegenerating = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isRegenerating)
        {
            StartCoroutine(RegenerarCadaSegundos());
        }
    }

    IEnumerator RegenerarCadaSegundos()
    {
        isRegenerating = true;
        while (true)
        {
            Debug.Log("Regenerando vida");
            handlerGame.regenerarVida(100);

            yield return new WaitForSeconds(1f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            isRegenerating = false;
        }
    }
}
