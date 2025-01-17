using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public int attackDamageUp = 15; // Da�o del ataque hacia arriba
    public int attackDamageDown = 20; // Da�o del ataque hacia abajo
    public int attackDamageRight = 25; // Da�o del ataque hacia la derecha
    private List<EnemyLife> enemiesInRange = new List<EnemyLife>();
    private int comboMultiplier = 1;

    // Referencia al sistema de puntuaci�n
    private ScoreComboSystem scoreSystem;

    // Lista para registrar los ataques realizados (para combos)
    private List<string> attackSequence = new List<string>();
    private float comboResetTime = 2.0f; // Tiempo para resetear el combo
    private float lastAttackTime;

    // Referencia al script de animaciones
    public Animator animator;  // Aseg�rate de que esto est� visible en el Inspector
    private bool isInCombat = false;
    public float attackAnimationDuration = 1.0f;
    // public PlayerFightingAnimation playerFightingAnimation;

    void Start()
    {
        // Buscar el sistema de puntuaci�n en la escena
        scoreSystem = FindObjectOfType<ScoreComboSystem>();
        if (scoreSystem == null)
        {
            Debug.LogError("No se encontr� el sistema de puntuaci�n en la escena.");
        }
        // Obtener referencia al script de animaciones
        animator = GetComponent<Animator>();
       // playerFightingAnimation = GetComponent<PlayerFightingAnimation>();
    }

    void Update()
    {
        // Detectar ataques y realizar acciones
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PerformAttack("Left", attackDamage);
            //Debug.Log("izquierda");
            animator.SetBool("isFighting", true);
            StartCoroutine(BackToIdle());
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PerformAttack("Up", attackDamageUp);
            //Debug.Log("arriba");
            animator.SetBool("isFighting", true);
            StartCoroutine(BackToIdle());
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PerformAttack("Down", attackDamageDown);
            //Debug.Log("abajo");
            animator.SetBool("isFighting", true);
            StartCoroutine(BackToIdle());
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PerformAttack("Right", attackDamageRight);
            //Debug.Log("derecha");
            animator.SetBool("isFighting", true);
            StartCoroutine(BackToIdle());
        }

        // Resetear combo si pasa el tiempo l�mite
        if (Time.time - lastAttackTime > comboResetTime && attackSequence.Count > 0)
        {
            attackSequence.Clear();
            //Debug.Log("Combo reseteado");
        }

    }

    private IEnumerator BackToIdle()
    {
        // Esperar la duraci�n de la animaci�n de ataque
        yield return new WaitForSeconds(attackAnimationDuration);

        // Volver al estado Idle, cambiando el par�metro 'isFighting' a false o cualquier otro que tengas
        animator.SetBool("isFighting", false);
    }

    private void PerformAttack(string attackDirection, int damage)
    {
        foreach (EnemyLife enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);

                // Actualizar puntuaci�n por el ataque
                if (scoreSystem != null)
                {
                    scoreSystem.AddScore(damage); // Puntos igual al da�o infligido
                }

                Debug.Log($"Ataque {attackDirection} realizado. Da�o infligido: {damage}");
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
                Debug.Log("�Combo especial ejecutado! Secuencia: Left-Up-Right");
                if (scoreSystem != null)
                {
                    scoreSystem.AddScore(100); // Puntuaci�n adicional por el combo
                }
                attackSequence.Clear(); // Limpiar secuencia tras ejecutar el combo
            }
            else if (combo.Contains("Up-Down-Left"))
            {
                Debug.Log("�Combo especial ejecutado! Secuencia: Up-Down-Left");
                if (scoreSystem != null)
                {
                    scoreSystem.AddScore(150); // Puntuaci�n adicional por el combo
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


