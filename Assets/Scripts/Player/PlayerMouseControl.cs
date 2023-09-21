using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseControl : MonoBehaviour
{
    public float rotationSpeed = 100f;
    
    [SerializeField] private Camera playerCamera; 

    
    void Start()
    {
        playerCamera = Camera.main;
        
    }
    
    private void Update()
    {
        RotateCharacterWithMouse();
    }
    

    private void RotateCharacterWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        var position1 = transform.position;
        Vector3 position = new Vector3(position1.x, 0, position1.z);
        Vector3 worldMousePosition = Camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.y));
        Vector3 lookDirection = worldMousePosition - position;
        lookDirection.y = 0;
        
        // transform.LookAt(transform.position + lookDirection, Vector3.up);

        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    
}
