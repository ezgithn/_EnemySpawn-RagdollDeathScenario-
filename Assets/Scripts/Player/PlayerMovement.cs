using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    
    public float moveSpeed = 5.0f;
    private float IsGrounded;
    public bool IsRunning;
    
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        HandleMovementInput();
        HandleActions();
        DeActivateMovement();
    }
    
    private void HandleMovementInput()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
    
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();
    
        //_rb.velocity = movement * moveSpeed;
    
        // Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        // _rb.MovePosition(newPosition);
        
        IsRunning = movement.magnitude > 0f;
        
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            
            
            Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
            _rb.MovePosition(newPosition);
            
            IsRunning = true;
            transform.rotation = Quaternion.LookRotation(movement);
            _animator.SetBool("IsRunning", true);
            _animator.SetTrigger("Run");
            
            _animator.SetBool("IsGrounded", true);
            _animator.SetTrigger("HighSpinAttack");
        }
        // else if(!IsRunning)
        // {
        //     _rb.velocity = Vector3.zero;
        //     IsRunning = false;
        //     _animator.SetBool("IsRunning", false);
        //     
        // }
        
    }
    
    void DeActivateMovement()
    {
        if (Vector3.Distance(transform.position, _rb.position) < 0.1f)
        {
            _animator.SetBool("IsRunning", false);
            _rb.velocity = Vector3.zero;
        }
    }
    
    private void HandleActions()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _animator.SetTrigger("Crouch");
        }
    
        if (Input.GetKey(KeyCode.R))
        {
            _animator.SetTrigger("Slash");
        }
    
        if (Input.GetKey(KeyCode.Q))
        {
            _animator.SetTrigger("HighSpinAttack");
        }
    }
    
   
}
