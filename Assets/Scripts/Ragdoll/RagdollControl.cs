using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;

    private void Start()
    {
        
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();

        
        SetRagdollEnabled(false);
    }

    public void SetRagdollEnabled(bool isEnabled)
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = !isEnabled;
        }

        foreach (Collider col in colliders)
        {
            col.enabled = isEnabled;
        }
    }
}
