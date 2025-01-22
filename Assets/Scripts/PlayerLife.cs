using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    private bool isAlive = true;

    private Animator animator;

    private AudioSource audioSource;

    public AudioClip damageSound;

    void Start()
    {
        // Inicializar la vida al máximo
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;

        //sonido daño
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
        }


        if (currentHealth > 0)
        {
            animator.SetTrigger("beenHit");
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para verificar si el jugador sigue vivo
    public bool IsAlive()
    {
        return isAlive;
    }

    private void Die()
    {
        isAlive = false;

        animator.SetTrigger("Die");

        Debug.Log("El jugador ha muerto.");

        // Espera a que la animación de muerte termine
        StartCoroutine(WaitForDeathAnimation());
    }

    private IEnumerator WaitForDeathAnimation()
    {
        // Aquí puedes poner la duración de la animación de muerte si no tienes un Blend Tree o "DeathProgress"
        float deathAnimationDuration = 3.5f; // Asegúrate de ajustar esto al tiempo de tu animación de muerte
        yield return new WaitForSeconds(deathAnimationDuration);

        // Ahora que la animación ha terminado, carga la escena de Hasmuerto
        SceneManager.LoadScene("Hasmuerto");
    }
}