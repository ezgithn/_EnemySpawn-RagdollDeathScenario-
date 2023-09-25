using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineRandom = UnityEngine.Random;	



	public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public int numberOfEnemies;
    public Transform playerTransform;
    public Transform[] spawnPoints;
    public Vector3 randomSpawnPos;
    
    [SerializeField]
    public float spawnInterval;
    private float lastSpawnTime;
    public float spawnRadius;
    
    private List<GameObject>enemyPool = new List<GameObject>();

    [SerializeField]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    private void Start()
    {
	 InvokeRepeating(nameof(SpawnEnemy), 5f, spawnInterval);
	  GetRandomSpawnPosition();
	
    }
    
    private void Update()
    {
	    if (Time.time - lastSpawnTime >= spawnInterval)
	    {
		    SpawnEnemy();
		    lastSpawnTime = Time.time;
	    }
    }

    private void SpawnEnemy()
    {
	  Vector3 randomSpawnPos = playerTransform.position + Random.insideUnitSphere * spawnRadius;
	  randomSpawnPos.y = 5f;
	 
	  for (int i = 0; i < 20; i++)
	 
		 foreach (GameObject enemy in enemyPool)
		 {
			 if (!enemy.activeInHierarchy)
			 {
				 Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
				 enemy.transform.position = spawnPoint.position;
				 enemy.SetActive(true);
					
				 break; 
			 }
		 }
	 
	 Instantiate(enemyPrefab, randomSpawnPos, Quaternion.identity);
    }


    private void GetRandomSpawnPosition()
    {
	  Vector3 randomSpawnPos = Vector3.zero;
	  RaycastHit hit;
	 
	  float raycastHeight = 2f;
	  Ray ray = new Ray(new Vector3(Random.Range(minX, maxX), raycastHeight, Random.Range(minZ, maxZ)), Vector3.down);
  
	  if (Physics.Raycast(ray, out hit))
	  {
		randomSpawnPos = hit.point;
	  }
    }
    
    
  }



