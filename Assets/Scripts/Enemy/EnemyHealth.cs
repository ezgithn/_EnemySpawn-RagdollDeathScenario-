using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    public int maxHealth = 2; 
    private int _currentHealth; 
    private bool _isDead;
    
    private Rigidbody[] ragdollRigidbodies;
    private RagdollControl ragdollController;

    private void Start()
    {
        _currentHealth = maxHealth; 
        // ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
         ragdollController = GetComponent<RagdollControl>();
        TakeDamage(int .MaxValue);
    }

    // public void Update()
    // {
    //     EnableRagdoll();
    // }

    public void TakeDamage(float damage)
    {
        _currentHealth -= (int)damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        EnableRagdoll();
        // ragdollController.SetRagdollEnabled(true);
        
        StartCoroutine(DestroyAfterDelay(3f));
    }
    
    private void EnableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
        }
    }
    
    private void DisableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }
    }
    
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
