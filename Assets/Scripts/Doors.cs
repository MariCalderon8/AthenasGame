using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject objetoMostrar;
    [SerializeField] private string siguienteEscena;
    private bool jugadorInTrigger;

    void Start()
    {
        objetoMostrar.SetActive(false);
        jugadorInTrigger = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objetoMostrar.SetActive(true);
	    jugadorInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objetoMostrar.SetActive(false);
	        jugadorInTrigger = false;
        }
    }

    void Update()
    {
        if (jugadorInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(siguienteEscena);
        }
    }


}
