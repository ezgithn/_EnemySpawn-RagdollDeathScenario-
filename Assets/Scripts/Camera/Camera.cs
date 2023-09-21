using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Camera : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0f, 3f, -5f); 
    public float smoothSpeed = 5f;
    public static Camera main { get; set; }

    
    private void Awake()
    {
        main = this;
    }

    private void LateUpdate()
    {
        if (!target)
            return;
        
        Vector3 desiredPosition = target.position + offset;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        
        transform.LookAt(target);
    }


    public static Vector3 ScreenToWorldPoint(Vector3 vector3)
    {
        throw new System.NotImplementedException();
    }
    
}
