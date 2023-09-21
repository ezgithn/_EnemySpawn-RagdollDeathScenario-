using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDustEffectController : MonoBehaviour
{
    public ParticleSystem dustParticleSystem1; 
    public ParticleSystem dustParticleSystem2;

    private PlayerMovement playerMovement; 

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); 
        dustParticleSystem1.Stop(); 
        dustParticleSystem2.Stop();
    }

    private void Update()
    {
        if (playerMovement.IsRunning && !dustParticleSystem1.isPlaying)
        {
            dustParticleSystem1.Play();
            
        }
        else if (!playerMovement.IsRunning && dustParticleSystem1.isPlaying)
        {
            dustParticleSystem1.Stop();
        }
        
        if (playerMovement.IsRunning && !dustParticleSystem2.isPlaying)
        {
            dustParticleSystem2.Play();
            
        }
        else if (!playerMovement.IsRunning && dustParticleSystem2.isPlaying)
        {
            dustParticleSystem2.Stop();
        }
    }
}
