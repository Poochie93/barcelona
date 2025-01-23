using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    // Vida inicial del enemigo
    public int maxHealth = 100;
    private int currentHealth;

    public Animator animator;  //esté visible en el Inspector
    private bool isDead = false;  // Bool para verificar si el enemigo ya está muerto

    private AudioSource audioSource;

    public AudioClip damageSound;

    // Método que se ejecuta al iniciar el juego
    void Start()
    {
        // Inicializamos la vida del enemigo con su valor máximo
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }


    // Método para reducir la vida del enemigo
    public void TakeDamage(int damage)
    {
        // Reducimos la vida actual
        currentHealth -= damage;
        ScoreScript.scoreValueHit += 13;

        if (isDead) return;  // Si el enemigo ya está muerto, no recibe más daño

        //sonido daño
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        // Comprobamos si la vida ha llegado a cero o menos
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método que se ejecuta cuando la vida del enemigo llega a cero
    private void Die()
    {
        if (isDead) return;  // Evita que la animación de muerte se inicie más de una vez

        isDead = true;  

        animator.SetTrigger("Die");

        // Usamos una Coroutine para esperar el tiempo de la animación de muerte
        StartCoroutine(WaitForDeathAnimation());
    }

    private IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitForSeconds(3.5f);  

        Destroy(gameObject);
    }

    // Método para verificar si el enemigo está muerto
    public bool IsDead()
    {
        return isDead;
    }
}

