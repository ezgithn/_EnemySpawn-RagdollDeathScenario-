using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; 
    private int _currentHealth; 

    private void Start()
    {
        _currentHealth = maxHealth;
    }
    
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         TakeDamage(1);
    //     }
    // }
    
    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        //karakter ölürse oyunu yeniden başlatmak gibi komutları buraya eklicem
        
        if (_currentHealth <= 0)
        {
            // Ölüm işlemleri
        }
    }
}
