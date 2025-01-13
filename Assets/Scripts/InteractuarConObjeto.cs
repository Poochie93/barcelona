using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarConObjeto : MonoBehaviour
{
    // Referencia al objeto de la mano del jugador
    public Transform manoJugador;
    // Referencia al objeto que el jugador puede agarrar
    private GameObject objetoRecogido;

    // Este método detecta el colisionador
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en la zona es el objeto que puede ser recogido
        if (other.CompareTag("ObjetoRecogible") && objetoRecogido == null)
        {
            Debug.Log("Jugador ha tocado el objeto");
        }
    }

    // Update se ejecuta cada frame
    void Update()
    {
        // Si el jugador presiona la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objetoRecogido == null)
            {
                // Comprobar si hay algún objeto que el jugador pueda recoger
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f); // Detecta objetos cercanos en un radio de 2 unidades
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.CompareTag("ObjetoRecogible"))
                    {
                        RecogerObjeto(hitCollider.gameObject);
                        break; // Detener el ciclo después de recoger el primer objeto
                    }
                }
            }
           
        }
    }

    // Método para recoger el objeto
    private void RecogerObjeto(GameObject objeto)
    {
        objetoRecogido = objeto;
        objetoRecogido.transform.SetParent(manoJugador);
        objetoRecogido.transform.localPosition = Vector3.zero; // Colócalo en la posición local de la mano
        objetoRecogido.transform.localRotation = Quaternion.identity; // Asegúrate de que no tiene rotación

        // Desactivar la física (si tiene Rigidbody) para que no se vea afectado por gravedad o colisiones
        Rigidbody rb = objetoRecogido.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Desactiva la física para que no caiga
        }

        // Desactivar el collider para evitar que el objeto siga colisionando mientras esté en la mano
        Collider collider = objetoRecogido.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false; // Desactiva el collider para que no detecte más colisiones
        }
    }
}