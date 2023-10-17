using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 2; 
    private int _currentHealth; 
    private bool _isDead;
    
    private Rigidbody[] ragdollRigidbodies;

    private void Start()
    {
        _currentHealth = maxHealth; 
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        // DisableRagdoll();
        // TakeDamage(int .MaxValue);
    }
    
    public void TakeDamage(int damageAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damageAmount;
            
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        _isDead = true;
        EnableRagdoll();
        //Düşmanın öldükten sonra yok olması//
        
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
