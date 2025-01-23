using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class CambiarDeEscena2 : MonoBehaviour
{
    // Método que se llama cuando se produce una colisión con otro objeto que tiene un Collider marcado como Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Colisión detectada con: " + other.gameObject.name); // Esto te dirá con qué objeto estás colisionando

        // Verifica si el objeto con el que hemos colisionado tiene la etiqueta "Puerta"
        if (other.CompareTag("Puerta"))
        {
            // Llama al método para cambiar de escena
            CambiarDeEscena();
        }
    }

    // Método para cambiar de escena
    private void CambiarDeEscena()
    {
        // Aquí puedes especificar el nombre de la nueva escena
        SceneManager.LoadScene("Nivel3");  // Cambia "NombreDeLaEscena" por el nombre de la escena que deseas cargar
    }
}