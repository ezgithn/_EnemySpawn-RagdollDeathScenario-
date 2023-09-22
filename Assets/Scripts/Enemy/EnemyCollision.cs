using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCollision : MonoBehaviour
{
    private RagdollController ragdollController;

    private void Start()
    {
        ragdollController = GetComponent<RagdollController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) // Karaktere çarpışma algılandığında Ragdoll'u etkinleştirmek için RagdollController!!!
        {
            ragdollController.SetRagdollEnabled(true);
        }
    }
}

internal class RagdollController
{
    public void SetRagdollEnabled(bool b)
    {
        throw new System.NotImplementedException();
    }
}
