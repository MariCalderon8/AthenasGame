using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class ActivarCinematica2 : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private bool jugadorEnTrigger = false;
    public GameObject objetoMostrar;

    void Start()
    {
        objetoMostrar.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objetoMostrar.SetActive(true);
            jugadorEnTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTrigger = false;
            objetoMostrar.SetActive(false);
        }
    }


    void Update()
    {
        if (jugadorEnTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (playableDirector != null)
            {
                playableDirector.Play();
            }
        }
    }
}
