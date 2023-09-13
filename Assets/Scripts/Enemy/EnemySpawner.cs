using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2.0f;

    private void Start()
    {
        // Belirli aralıklarla düşmanları yaratmak için InvokeRepeating kullanıyoruz
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // Düşmanı spawn noktasında oluşturmak için Instantiate kullanıyoruz
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
