using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    // Vida m�xima y actual del jugador
    public int maxHealth = 100;
    public int currentHealth = 100;

    // Bandera para saber si el jugador est� vivo
    private bool isAlive = true;

    // Start se llama antes del primer frame
    void Start()
    {
        // Inicializar la vida al m�ximo
        currentHealth = maxHealth;
    }

    // M�todo para recibir da�o
    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            SceneManager.LoadScene("Hasmuerto");
        }
    }

    // M�todo para manejar la muerte del jugador
    private void Die()
    {
        isAlive = false;
        Debug.Log("El jugador ha muerto.");
        // Aqu� puedes agregar l�gica adicional, como mostrar Game Over o bloquear el control.
    }

    // M�todo para verificar si el jugador sigue vivo
    public bool IsAlive()
    {
        return isAlive;
    }
}
