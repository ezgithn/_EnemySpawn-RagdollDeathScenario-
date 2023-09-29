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
        MovementInput();
        SetTarget(targetPoint);
    }

    private void MovementInput()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();

        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        
        IsWalking = movement.magnitude > 0f;

        if (movement.x > 0f || movement.x < 0f || movement.z > 0f || movement.z < 0f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            _animator.SetTrigger("Walk");
        }

        _rigidbody.velocity = Vector3.zero;

    }
}
