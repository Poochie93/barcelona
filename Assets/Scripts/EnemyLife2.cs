using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife2 : MonoBehaviour
{
    public int maxHealth = 1000; // Configura un valor alto para que aguante más golpes
    private int currentHealth;

    // Método que se ejecuta al iniciar el juego
    void Start()
    {
        // Inicializamos la vida del enemigo con su valor máximo
        currentHealth = maxHealth;
    }

    // Método para reducir la vida del enemigo
    public void TakeDamage(int damage)
    {
        // Reducimos la vida actual
        currentHealth -= damage;

        // Mostrar mensaje en consola sobre la vida restante
        Debug.Log($"Saco de boxeo golpeado. Vida restante: {currentHealth}");

        // Evitar que la vida sea menor que cero
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Mantener la vida en 0
            Debug.Log("El saco de boxeo está en 0 de vida, pero no será destruido.");
        }
    }

    // Método para reiniciar la vida (opcional, si deseas hacerlo manualmente)
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        Debug.Log("La vida del saco de boxeo ha sido reiniciada.");
    }
}
