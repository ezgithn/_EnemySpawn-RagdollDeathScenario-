using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Camera : MonoBehaviour
{
    public Transform target; 

    public float distance = 5f; 
    public float height = 2f; 
    public float rotationDamping = 3f; 

    
    private void LateUpdate()
    {
        if (!target)
            return;
        
        Vector3 targetPosition = target.position + Vector3.up * height;
       
        Vector3 desiredPosition = targetPosition - target.forward * distance;
       
        Quaternion desiredRotation = Quaternion.LookRotation(targetPosition - desiredPosition, Vector3.up);
        Transform transform1;
        (transform1 = transform).rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationDamping);

        transform1.position = desiredPosition;
    }
   
}
