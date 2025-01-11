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
        // Llamamos al método que cambiará la escena después de un retraso
        Invoke("CambiarDeEscena", tiempoDeEspera);
    }

    // Método que cambia la escena
    void CambiarDeEscena()
    {
        SceneManager.LoadScene("Scene");
    }
}