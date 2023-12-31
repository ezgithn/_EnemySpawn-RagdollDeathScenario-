using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimControl : MonoBehaviour
    {
        private Animator animator;
        private static readonly int Direction = Animator.StringToHash("Direction");
    
        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        
        // private void Update()
        // {
        //     var transformedVelocity = Quaternion.Euler(0, -transform.eulerAngles.y,0) * GetComponent<Rigidbody>().velocity;
        //     animator.SetTrigger("Run");
        //     animator.SetFloat(Direction, transformedVelocity.x);
        //     PlayRunAnimation();
        //     PlayHighSpinAttackAnimation();
        //     PlayIdleAnimation();
        // }
    
        
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
        
        public void Die()
        {
            animator.SetTrigger("Death");
            // Ölüm animasyonunun tamamlanmasından sonra ragdoll'u etkinleştirmek için AnimationComplete'i kullanıcam!!!
        }
        
        public void AnimationComplete()
        {
            
        }
    }
}

