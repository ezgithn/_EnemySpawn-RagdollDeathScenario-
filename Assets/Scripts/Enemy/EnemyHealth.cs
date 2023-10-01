using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    private int _currentHealth; 

    private void Start()
    {
        _currentHealth = maxHealth; 
    }
    
    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false); 
        }
    }
}
