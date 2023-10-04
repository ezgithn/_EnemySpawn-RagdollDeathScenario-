using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    private int _currentHealth; 
    private bool _isDead;
    
    private Rigidbody[] ragdollParts;

    private void Start()
    {
        _currentHealth = maxHealth; 
    }
    
    public void TakeDamage(int damage)
    {
        if (_isDead)
            return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        ActivateRagdoll();
        //Düşmanın öldükten sonra yok olması//
        
        StartCoroutine(DestroyAfterDelay(3f));
    }
    
    private void ActivateRagdoll()
    {
        ragdollParts = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in ragdollParts)
        {
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
        }
    }
    
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
