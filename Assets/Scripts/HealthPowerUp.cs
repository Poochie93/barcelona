using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip damageSound;
    public int healAmount = 40; // Cantidad de vida que restaura el power-up

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
  
        // Verificar si el jugador colisiona con el power-up
        PlayerLife playerLife = other.GetComponent<PlayerLife>();
        if (playerLife != null)
        {
            if (damageSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(damageSound);
            }
            // Aumentar la vida del jugador sin exceder el máximo
            int newHealth = Mathf.Min(playerLife.currentHealth + healAmount, playerLife.maxHealth);
            playerLife.currentHealth = newHealth;

            Debug.Log("Vida del jugador aumentada: " + playerLife.currentHealth);

            // Destruir el power-up tras recogerlo
            Destroy(gameObject);
        }
    }

    
        
    
}

