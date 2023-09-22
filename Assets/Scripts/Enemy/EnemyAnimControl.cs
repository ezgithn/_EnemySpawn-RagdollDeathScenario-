using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimControl : MonoBehaviour
{
    private Animator _animator;
    private RagdollController _ragdollController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _ragdollController = GetComponent<RagdollController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) //Karaktere çarpışma algılandığında Ragdoll'u etkinleştirmek için RagdollController!!!
        {
            _animator.enabled = false;
            _ragdollController.SetRagdollEnabled(true);
        }
    }
    
    
    
}
