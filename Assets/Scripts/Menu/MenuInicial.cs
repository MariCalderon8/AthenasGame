using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void iniciar()
    {
        SceneManager.LoadScene("Capitulo1");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
