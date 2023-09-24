using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl : MonoBehaviour
{
    public Transform playerTransform;
    private NavMeshAgent _navMeshAgent;

    public float maxSpeed = 3f;
    public float moveSpeed = 5f;
    public float horizontalInput;
    public float verticalInput;
    private Rigidbody _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(playerTransform.position);
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();
        
        if (movement.magnitude > maxSpeed)
        {
            movement = movement.normalized * maxSpeed;
        }
        
        _rigidbody.velocity = movement * moveSpeed;
        
    }
    
}
