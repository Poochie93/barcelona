using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;                // Velocidad del enemigo
    public float obstacleRange = 5.0f;       // Rango para evitar obstáculos
    public float followRange = 10.0f;        // Rango para comenzar a seguir al jugador
    public float stopDistance = 2.0f;        // Distancia mínima al jugador

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private bool _alive;
    private Transform playerTransform;

    void Start()
    {
        _alive = true;

        // Encontrar al jugador en la escena
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    void Update()
    {
        if (!_alive) return;

        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            // Si el jugador está dentro del rango de seguimiento
            if (distanceToPlayer < followRange && distanceToPlayer > stopDistance)
            {
                FollowPlayer();
            }
            else if (distanceToPlayer <= stopDistance)
            {
                // Detener movimiento cuando está dentro de la distancia mínima
                StopMovement();
            }
            else
            {
                // Movimiento errante
                Wander();
            }
        }
        else
        {
            // Si no hay jugador, continuar moviéndose erráticamente
            Wander();
        }
    }

    private void FollowPlayer()
    {
        // Girar hacia el jugador
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);

        // Moverse hacia el jugador
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void StopMovement()
    {
        // Opcional: Detén cualquier animación o efectos cuando el enemigo deja de moverse.
        Debug.Log("Jugador dentro de la zona segura, deteniendo movimiento.");
    }

    private void Wander()
    {
        // Movimiento errante
        transform.Translate(0, 0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate<GameObject>(fireballPrefab);
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}

