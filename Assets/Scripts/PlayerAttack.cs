using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public int attackDamageUp = 15; // Daño del ataque hacia arriba
    public int attackDamageDown = 20; // Daño del ataque hacia abajo
    public int attackDamageRight = 25; // Daño del ataque hacia la derecha
    private List<EnemyLife> enemiesInRange = new List<EnemyLife>();

    // Referencia al sistema de puntuación
    private ScoreComboSystem scoreSystem;

    // Lista para registrar los ataques realizados (para combos)
    private List<string> attackSequence = new List<string>();
    private float comboResetTime = 2.0f; // Tiempo para resetear el combo
    private float lastAttackTime;

    void Start()
    {
        // Buscar el sistema de puntuación en la escena
        scoreSystem = FindObjectOfType<ScoreComboSystem>();
        if (scoreSystem == null)
        {
            Debug.LogError("No se encontró el sistema de puntuación en la escena.");
        }
    }

    void Update()
    {
        // Detectar ataques y realizar acciones
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PerformAttack("Left", attackDamage);
            //Debug.Log("izquierda");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PerformAttack("Up", attackDamageUp);
            //Debug.Log("arriba");

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PerformAttack("Down", attackDamageDown);
            //Debug.Log("abajo");

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PerformAttack("Right", attackDamageRight);
            //Debug.Log("derecha");

        }

        // Resetear combo si pasa el tiempo límite
        if (Time.time - lastAttackTime > comboResetTime && attackSequence.Count > 0)
        {
            attackSequence.Clear();
            //Debug.Log("Combo reseteado");
        }
    }

    private void PerformAttack(string attackDirection, int damage)
    {
        foreach (EnemyLife enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);

                // Actualizar puntuación por el ataque
                if (scoreSystem != null)
                {
                    scoreSystem.AddScore(damage); // Puntos igual al daño infligido
                }

                Debug.Log($"Ataque {attackDirection} realizado. Daño infligido: {damage}");
            }
        }

        // Registrar el ataque en la secuencia
        attackSequence.Add(attackDirection);
        lastAttackTime = Time.time;

        // Comprobar si se ha realizado un combo
        CheckCombo();
    }

    private void CheckCombo()
    {
        // Ejemplo de combos
        if (attackSequence.Count >= 3)
        {
            string combo = string.Join("-", attackSequence);

            if (combo.Contains("Left-Up-Right"))
            {
                Debug.Log("¡Combo especial ejecutado! Secuencia: Left-Up-Right");
                if (scoreSystem != null)
                {
                    scoreSystem.AddScore(100); // Puntuación adicional por el combo
                }
                attackSequence.Clear(); // Limpiar secuencia tras ejecutar el combo
            }
            else if (combo.Contains("Up-Down-Left"))
            {
                Debug.Log("¡Combo especial ejecutado! Secuencia: Up-Down-Left");
                if (scoreSystem != null)
                {
                    scoreSystem.AddScore(150); // Puntuación adicional por el combo
                }
                attackSequence.Clear(); // Limpiar secuencia tras ejecutar el combo
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyLife enemy = other.GetComponent<EnemyLife>();
        if (enemy != null)
        {
            enemiesInRange.Add(enemy);
            //Debug.Log("Enemigo detectado: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyLife enemy = other.GetComponent<EnemyLife>();
        if (enemy != null)
        {
            enemiesInRange.Remove(enemy);
            //Debug.Log("Enemigo fuera de rango: " + other.name);
        }
    }
}


