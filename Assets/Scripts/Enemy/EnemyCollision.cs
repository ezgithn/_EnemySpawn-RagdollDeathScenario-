using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyCollision : MonoBehaviour
{
    private RagdollControl ragdollController;
    private bool _isDead;

    private void Start()
    {
        _isDead = false;
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (!_isDead && collision.gameObject.CompareTag("Sword"))
    //     {
    //         Die();
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isDead && other.gameObject.CompareTag("Sword"))
        {
            Die();
        }
    }
    private void Die()
    {
        _isDead = true;
        ragdollController.SetRagdollEnabled(true);
    }
    
}

