using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Camera : MonoBehaviour
{
    public static object main { get; set; }
    
   public Transform target;
   
   public Camera camera;
   
   
   public void Update()
   {
       transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
   }
   
   public void Start()
   {
       main = this;
   }
   
   public void ScreenPointToRay(Vector3 mousePosition)
   {
       throw new System.NotImplementedException();
   }
   
   
}
