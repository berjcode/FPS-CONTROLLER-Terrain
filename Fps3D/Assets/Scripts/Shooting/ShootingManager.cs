using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TankShooter.Shooting{
public class ShootingManager : MonoBehaviour
{


    
   public void Shoot(Vector3 from, Vector3 direction)
   {
    RaycastHit hit;

    bool rayHit = Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity);
    if (rayHit)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.name);
            Debug.Log("Did Hit");
        }

   }
}
}