using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Camera : MonoBehaviour
{
   public Transform target;

   public Camera mainCamera;
   // public static object main { get; set; }
   // public static object ScreenToWorldPoint { get; internal set; }


   public void Update()
   {
       transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
       
   }
   
}
