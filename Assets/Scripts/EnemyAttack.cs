using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Referencia a la vida del jugador
    public PlayerLife player;

    // Daño que el enemigo inflige al jugador
    public int attackDamage = 10;

    // Rango de ataque del enemigo
    public float attackRange = 2f;

    // Tiempo entre ataques
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    // Update se llama una vez por frame
    void Update()
    {
        // Verificar si el jugador sigue vivo y está en rango
        if (player != null && player.IsAlive() && Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            // Verificar si ha pasado suficiente tiempo desde el último ataque
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    // Método para infligir daño al jugador
    private void AttackPlayer()
    {
        if (player != null)
        {
            player.TakeDamage(attackDamage);
            Debug.Log("El enemigo infligió daño al jugador. Vida restante: " + player.currentHealth);
        }
    }

    // Dibujar el rango de ataque en la escena
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
