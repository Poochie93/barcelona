using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    // Vida inicial del enemigo
    public int maxHealth = 100;
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

        // Comprobamos si la vida ha llegado a cero o menos
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método que se ejecuta cuando la vida del enemigo llega a cero
    private void Die()
    {
        // Aquí puedes agregar efectos, sonidos, etc.
        Debug.Log("El enemigo ha sido derrotado");

        // Destruir el objeto del enemigo
        Destroy(gameObject);
    }
}

