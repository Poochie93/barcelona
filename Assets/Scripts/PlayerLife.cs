using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    // Vida máxima y actual del jugador
    public int maxHealth = 100;
    public int currentHealth = 100;

    // Bandera para saber si el jugador está vivo
    private bool isAlive = true;

    // Referencia al Animator para las animaciones
    private Animator animator;

    // Contador de golpes consecutivos que el jugador recibe
    private int consecutiveHits = 0;

    // Start se llama antes del primer frame
    void Start()
    {
        // Inicializar la vida al máximo
        currentHealth = maxHealth;

        // Obtener el componente Animator
        animator = GetComponent<Animator>();
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;

        // Incrementar el contador de golpes consecutivos
        consecutiveHits++;

        // Si el jugador ha recibido más de 3 golpes consecutivos, animación más fuerte
        if (consecutiveHits > 3)
        {
            animator.SetTrigger("bigHit"); 
        }
        else
        {
            // Reproducir la animación de golpeado normal
            animator.SetTrigger("beenHit");
        }

        if (currentHealth <= 0)
        {
            Die();
            SceneManager.LoadScene("Hasmuerto");
        }
    }

    // Método para manejar la muerte del jugador
    private void Die()
    {
        isAlive = false;

        //animación de muerte
        animator.SetTrigger("Die");


        Debug.Log("El jugador ha muerto.");
        // Aquí puedes agregar lógica adicional, como mostrar Game Over o bloquear el control.
    }

    // Método para verificar si el jugador sigue vivo
    public bool IsAlive()
    {
        return isAlive;
    }
}
