using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCollision : MonoBehaviour
{
    private RagdollControl ragdollController;
    private bool _isDead;

    private void Start()
    {
        // ragdollController = GetComponent<RagdollControl>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isDead && collision.gameObject.CompareTag("Sword"))
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

