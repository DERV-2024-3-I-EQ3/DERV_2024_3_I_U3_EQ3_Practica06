using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioPersecucion;
    private bool IsFollowing = false;

    private Coroutine CoroutinePersecusion = null;

    public void activarSonidoPersecusion()
    {
        this.IsFollowing = true;
        if (CoroutinePersecusion == null)
        {
            CoroutinePersecusion = StartCoroutine(ControlarSonidoPersecucion());
        }
    }

    public void desactivarSonidoPersecusion()
    {
        this.IsFollowing = false;
        if (CoroutinePersecusion != null)
        {
            StopCoroutine(CoroutinePersecusion);
            audioPersecucion.Stop();
            CoroutinePersecusion = null;
        }
    }

    IEnumerator ControlarSonidoPersecucion()
    {
        while (IsFollowing)
        {
            if (!audioPersecucion.isPlaying)
            {
                audioPersecucion.Play();
            }
            yield return new WaitForSeconds(0.5f);
        }
        CoroutinePersecusion = null;
    }


}
