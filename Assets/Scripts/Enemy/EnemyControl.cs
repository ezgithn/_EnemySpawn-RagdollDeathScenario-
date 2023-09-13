using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Düşmanı karakterin konumuna doğru hareket ettiğimiz için NavMeshAgent kullanıyoruz!!!
        navMeshAgent.SetDestination(player.position);
    }
}
