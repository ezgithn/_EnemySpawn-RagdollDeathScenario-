using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    
    public float moveSpeed = 5.0f;
    private float IsGrounded;
    public bool IsRunning { get; set; }
    
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        HandleMovementInput();
        HandleActions();
    }
    
    private void HandleMovementInput()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
    
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();
    
        //_rb.velocity = movement * moveSpeed;
    
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        _rb.MovePosition(newPosition);
        
        IsRunning = movement.magnitude > 0f;
        
        if (movement.x > 0f || movement.x < 0f || movement.z > 0f || movement.z < 0f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    
        if (movement.z > 0f)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }
    
    private void HandleActions()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _animator.SetTrigger("Crouch");
        }
    
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Slash");
        }
    
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
        {
            _animator.SetTrigger("HighSpinAttack");
        }
    }
    
   
}
