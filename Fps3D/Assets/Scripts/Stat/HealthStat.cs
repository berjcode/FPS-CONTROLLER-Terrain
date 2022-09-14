using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStat : MonoBehaviour
{
    private float  health = 100;

    public void Hit(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            Debug.Log("Health zero");
        }
    }
}
