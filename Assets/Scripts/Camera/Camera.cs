using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Camera : MonoBehaviour
{
    // public Transform target; 
    //
    // public float distance = 5f; 
    // public float height = 2f; 
    // public float rotationDamping = 3f; 
    //
    //
    // private void LateUpdate()
    // {
    //     if (!target)
    //         return;
    //     
    //     Vector3 targetPosition = target.position + Vector3.up * height;
    //    
    //     Vector3 desiredPosition = targetPosition - target.forward * distance;
    //    
    //     Quaternion desiredRotation = Quaternion.LookRotation(targetPosition - desiredPosition, Vector3.up);
    //     Transform transform1;
    //     (transform1 = transform).rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationDamping);
    //
    //     transform1.position = desiredPosition;
    // }
    
    public Transform Target { get; set; }
    private const float FOLLOW_SPEED = 5;
    private const float ACCEPTANCE_RADIUS = 1;
		
    private bool _reachedDestination;
    

    private Vector3 _smoothMovementVelocity;
		
		

    private void Update()
    {
        if (Target)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref _smoothMovementVelocity,FOLLOW_SPEED * Time.deltaTime);

            if (Vector3.Distance(Target.position, transform.position) < ACCEPTANCE_RADIUS)
            {
                if (!_reachedDestination)
                {
                    _reachedDestination = true;
                }
            }
            else
            {
                _reachedDestination = false;
            }
        }
    }
   
}
