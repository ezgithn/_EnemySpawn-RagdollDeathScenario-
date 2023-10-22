using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    
    public float moveSpeed;
    private float IsGrounded;
    public bool IsRunning;
    public bool IsAttacking;
    public float attackDamage;
    public ParticleSystem _swordVfx;
    
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _swordVfx.Stop();
    }
    
    private void Update()
    {
        HandleMovementInput();
        HandleActions();
        StartCoroutine(StopAttack());
        if (IsAttacking)
        {
            _rb.velocity = Vector3.zero;
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void HandleMovementInput()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
    
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();
        _rb.velocity = movement * moveSpeed;
        
        Debug.Log(movement.magnitude);
        IsRunning = movement.magnitude > 0f;
        
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            Vector3 newPosition = transform.position + movement * (moveSpeed * Time.deltaTime);
            _rb.MovePosition(newPosition);
            
            IsRunning = true;
            transform.rotation = Quaternion.LookRotation(movement);
            _animator.SetBool("IsRunning", true);
            _animator.SetTrigger("Run");
            
        }
        else if(movement.Equals(Vector3.zero))
        {
            _rb.velocity = Vector3.zero;
            IsRunning = false;
            _animator.SetBool("IsRunning", false);
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
    
        if (Input.GetKey(KeyCode.Q) && !IsAttacking)
        {
            IsAttacking = true;
            _animator.SetBool("IsAttacking", true);
            _animator.SetTrigger("HighSpinAttack");
            _swordVfx.Play();
            
        }
    }

    private void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                IDamageExecutor.TakeDamage(damageable, attackDamage);
            }
        }
    }
    
    private IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(1f);
        IsAttacking = false;
        _animator.SetBool("IsAttacking", false);
        _swordVfx.Stop();
    }
    
   
}
