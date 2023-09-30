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
    
    public float maxSpeed = 3f;
    public float moveSpeed = 5f;
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
    
    public void Update()
    {
        MovementInput(targetPoint.position);
        SetTarget(targetPoint);
    }

    private void MovementInput(Vector3 targetPoint)
    {
        
        Vector3 moveDirection = (targetPoint - transform.position).normalized;
        float horizontalInput = moveDirection.x;
        float verticalInput = moveDirection.z;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        
        IsWalking = movement.magnitude > 5f;

        if (movement.x > 5f || movement.x < 5f || movement.z > 5f || movement.z < 5f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            _animator.SetTrigger("Walk");
        }

        _rigidbody.velocity = Vector3.zero;

    }
}
