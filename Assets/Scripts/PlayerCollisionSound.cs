using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionSound : MonoBehaviour
{
    public AudioClip collisionSound; // El clip de audio que se reproducirá al colisionar
    private AudioSource audioSource; // Componente AudioSource para reproducir el sonido

    void Start()
    {
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Verificar si no se ha asignado un AudioSource
        if (audioSource == null)
        {
            Debug.LogError("No se ha encontrado un AudioSource en el objeto.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Depurar: Verificar si se está detectando la colisión
            Debug.Log("¡El jugador ha tocado el objeto!");

            // Verificar si hay un AudioClip y un AudioSource
            if (collisionSound != null && audioSource != null)
            {
                // Reproducir el sonido de la colisión
                audioSource.PlayOneShot(collisionSound);

                // Llamar a la corrutina para destruir el objeto después de que termine el sonido
                StartCoroutine(DestroyAfterSound());
            }
            else
            {
                Debug.LogWarning("No se ha asignado un AudioClip o AudioSource.");
            }
        }
    }

    // Corrutina que espera a que termine el sonido y luego destruye el objeto
    IEnumerator DestroyAfterSound()
    {
        // Esperar a que termine de sonar el clip de audio
        yield return new WaitForSeconds(collisionSound.length);

        // Destruir el objeto
        Destroy(gameObject);
    }
}
