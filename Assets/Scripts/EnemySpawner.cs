using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array para múltiples tipos de enemigos
    public Transform[] spawnPoints;  // Puntos donde se pueden generar los enemigos
    public float spawnInterval = 2f; // Intervalo de tiempo entre spawns
    public int maxEnemies = 10;      // Número máximo de enemigos activos

    private int currentEnemyCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemies) return;

        // Selecciona un prefab y un punto aleatorio
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instancia el enemigo
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        currentEnemyCount++;
    }

    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
