using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public int maxEnemies = 10; 
	public Transform[] spawnPoints;
	public float spawnInterval = 5f;
	public float spawnRadius = 10f;

	private List<GameObject> enemyPool = new List<GameObject>();
	private int currentEnemyCount = 0; 
	private bool spawningFinished = false;
	private float lastSpawnTime;

	private void Start()
	{
		for (int i = 0; i < maxEnemies; i++)
		{
			GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
			enemy.SetActive(false);
			enemyPool.Add(enemy);
		}
		
		lastSpawnTime = Time.time;
		InvokeRepeating(nameof(SpawnEnemy), 5f, spawnInterval);
		// Invoke(nameof(SpawnEnemy), 5f);
	}

	private void Update()
	{
		if (spawningFinished)
		{
			CancelInvoke(nameof(SpawnEnemy));
		}
	}

	private void SpawnEnemy()
	{
		if (currentEnemyCount < maxEnemies)
		{
			Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
			Vector3 randomSpawnPos = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
			randomSpawnPos.y = 0f;
			
			GameObject enemy = enemyPool.Find(e => !e.activeSelf);
			if (enemy != null)
			{
				enemy.transform.position = randomSpawnPos;
				enemy.SetActive(true);
				currentEnemyCount++;
			}
			
			if (currentEnemyCount >= maxEnemies)
			{
				spawningFinished = true;
			}
			
		}
	}
}


