using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimControl : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private RagdollControl _ragdollController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _ragdollController = GetComponent<RagdollControl>();
        PlayAnimation();
    }
    
    public void PlayAnimation()
    {
        _animator.SetTrigger("Walk");
    }
    public void SetRagdollEnabled(bool b)
    {
        _ragdollController.SetRagdollEnabled(b);
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
