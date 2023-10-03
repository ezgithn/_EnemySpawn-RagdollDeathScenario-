using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;


public class EnemyControl : MonoBehaviour
{
    //public Transform playerTransform;

    public Transform targetPoint;
    private NavMeshAgent _navMeshAgent;
    
    //public float maxSpeed;
    public float moveSpeed;
    public float horizontalInput;
    public float verticalInput;
    private Rigidbody _rigidbody;
    private Animator _animator;
    public bool IsWalking { get; set; }


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    
    public void Update()
    {
        MovementInput(targetPoint.position);
        SetTarget(targetPoint);
    }
    
    public void SetTarget(Transform target)
    {
        target = targetPoint;

        if (_rigidbody != null && target != null)
        {
            Vector3 direction = target.position - _rigidbody.position;
            direction.Normalize();
            _rigidbody.velocity = target.position * moveSpeed;
        }
    }
    
    

    private void MovementInput(Vector3 targetPoint)
    {
        
        Vector3 moveDirection = (targetPoint - transform.position);
        float horizontalInput = moveDirection.x;
        float verticalInput = moveDirection.z;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 newPosition = transform.position + movement * (moveSpeed * Time.deltaTime);
        
        IsWalking = movement.magnitude > 0.1f;

        if (IsWalking)
        {
            movement.Normalize();
            transform.rotation = Quaternion.LookRotation(movement);
            _animator.SetTrigger("Walk");
        }

        _rigidbody.velocity = movement * moveSpeed;

    }
}
