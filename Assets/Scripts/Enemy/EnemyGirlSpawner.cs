using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGirlSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public float spawnInterval;
    public float spawnRadius;
    public float maxSpeed = 5.0f;
   
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

    private void SpawnEnemy()
    {
        Vector3 randomSpawnPos = playerTransform.position + Random.insideUnitSphere * spawnRadius;
        randomSpawnPos.y = 5f;

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
