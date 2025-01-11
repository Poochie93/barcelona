using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class videoInicio : MonoBehaviour
{
    // Tiempo en segundos antes de cambiar la escena
    public float tiempoDeEspera = 15f;
    // Nombre de la siguiente escena
    public string Scene;

    // Iniciar el temporizador
    private void Start()
    {
        // Llamamos al m�todo que cambiar� la escena despu�s de un retraso
        Invoke("CambiarDeEscena", tiempoDeEspera);
    }

    // M�todo que cambia la escena
    void CambiarDeEscena()
    {
        SceneManager.LoadScene("Scene");
    }
}