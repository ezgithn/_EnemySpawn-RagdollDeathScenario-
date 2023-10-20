using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl : MonoBehaviour
{
    public Transform targetPoint;
    //private NavMeshAgent _navMeshAgent;
    
    //public float maxSpeed;
    public float moveSpeed;
    public float horizontalInput;
    public float verticalInput;
    private Rigidbody _rigidbody;
    private Animator _animator;
    public bool _isWalking { get; set; }


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
    }
    
    public void Update()
    {
        MovementInput(targetPoint.position);
        SetTarget(targetPoint);
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, 10);
       
    }
    
    public void SetTarget(Transform target)
    {
        target = targetPoint;
        transform.LookAt(target);

        if (_rigidbody != null && target != null)
        {
            Vector3 direction = target.position - _rigidbody.position;
            direction.Normalize();
            _rigidbody.velocity = target.position * moveSpeed;
        }
    }

    public void MovementInput(Vector3 targetPoint)
    {
        Vector3 moveDirection = (targetPoint - transform.position);
        float horizontalInput = moveDirection.x;
        float verticalInput = moveDirection.z;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 newPosition = transform.position + movement * (moveSpeed * Time.deltaTime);
        
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, targetPoint.normalized);
        if (distance > 5f)
        {
            transform.LookAt(targetPoint);
        }
        
        _isWalking = movement.magnitude > 0.1f;

        if (_isWalking)
        {
            movement.Normalize();
            transform.rotation = Quaternion.LookRotation(movement);
            _animator.SetTrigger("Walk");
        }
        
        _rigidbody.velocity = movement * moveSpeed;

    }
}
