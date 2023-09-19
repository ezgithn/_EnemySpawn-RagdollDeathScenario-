using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMouseControl : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public Transform player; 
    public Camera mainCamera;
    
    
    
    private void Update()
    {
        RotateCharacterWithMouse();
    }

    private void RotateCharacterWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        var position = player.position;
        // mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, position.y));

        Vector3 lookDirection = mousePosition - position;
        lookDirection.y = 0f; 

        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            player.rotation = Quaternion.RotateTowards(player.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
