using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void PlayIdleAnimation()
    {
        animator.SetTrigger("Idle");
    }
    
    public void PlayRunAnimation()
    {
        animator.SetTrigger("Run" );
    }

    public void PlayCrouchingAnimation()
    {
        animator.SetTrigger("Crouch");
    }

    public void PlayHighSpinAttackAnimation()
    {
        animator.SetTrigger("HighSpinAttack");
    }

    public void PlaySlashAnimation()
    {
        animator.SetTrigger("Slash");
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("Death");
    }

    // Animasyonların sona erip etkisiz hale geldiğini bildiren bir geri arama yöntemi!!!
    public void AnimationComplete()
    {
        
    }
}
