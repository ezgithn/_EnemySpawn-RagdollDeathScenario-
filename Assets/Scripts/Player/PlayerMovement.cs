using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;

    
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();

        _rb.velocity = movement * moveSpeed;

        // Karakterin yönü.
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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

    public void Die()
    {
        // Düşmanla temas edildiğinde çağrılacak..
        _animator.SetTrigger("Death");
        // Ölüm animasyonunun tamamlanmasından sonra ragdoll'u etkinleştirmek
        // için Player Animation scriptindeki AnimationComplete kısmını kullan!!!
    }
}
