using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    private int _currentHealth; 
    public int currentHealth => _currentHealth;
    private Rigidbody[] ragdollRigidbodies;

    private void Start()
    {
        _currentHealth = maxHealth;
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(1);
        }
    }
    
    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        //karakter ölürse oyunu yeniden başlatmak gibi komutları buraya eklicemm
        
        if (currentHealth <= 0)
        {
            Debug.Log("Öldün");
            Die();
        }
    }
    
    private void Die()
    {
        EnableRagdoll();
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
    
}
