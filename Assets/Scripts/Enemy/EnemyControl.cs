using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;


public class EnemyControl : MonoBehaviour
{
    public Transform playerTransform;

    public Transform targetPoint;
    private NavMeshAgent _navMeshAgent;

    public float maxSpeed = 3f;
    public float moveSpeed = 5f;
    public float horizontalInput;
    public float verticalInput;
    private Rigidbody _rigidbody;


    private void Start()
    {
        // _rigidbody = GetComponent<Rigidbody>();
        _rigidbody = GetComponent<Rigidbody>();
        // playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // if (playerTransform != null)
        // {
        //     SetTarget(playerTransform);
        // }
        
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (targetPoint == null)
        {
            Debug.LogError("Hedef nokta (targetPoint) atanmamış.");
        }
        else
        {
            SetDestinationToTargetPoint();
        }
    }
    
    private void SetDestinationToTargetPoint()
    {
        _navMeshAgent.SetDestination(targetPoint.position);
    }
    
    public void SetTarget(Transform target)
    {
        target = playerTransform;

        if (_rigidbody != null && target != null)
        {
            Vector3 direction = target.position - _rigidbody.position;
            direction.Normalize();
            _rigidbody.velocity = target.position * moveSpeed;
        }
    }

    public void Update()
    {
        //_rigidbody.AddForce(playerTransform.position);
        MovementInput();
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f)
        {
            SetDestinationToTargetPoint();
        }
        
    }
    
    private void MovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 1f, verticalInput);
        movement.Normalize();
        
        Vector3 position = transform.position + movement * moveSpeed * Time.deltaTime;
        _rigidbody.MovePosition(position);
        
        if (movement.magnitude < maxSpeed)
        {
            _rigidbody.AddForce(movement * moveSpeed);
        }
    }
    
}
