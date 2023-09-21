using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMouseControl : MonoBehaviour
{
    public float rotationSpeed = 100f;
    
    [SerializeField] public Camera playerCamera; 

    private void Update()
    {
        RotateCharacterWithMouse();
    }

    private void RotateCharacterWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        var position = transform.position;
        Vector3 worldMousePosition = playerCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, position.y));
        Vector3 lookDirection = worldMousePosition - position;
        lookDirection.y = 0;

        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
