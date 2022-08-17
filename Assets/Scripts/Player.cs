using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject stick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 v = stick.transform.localScale;
            v.y = v.y + 0.1f;
            stick.transform.localScale = v;
        }
    }
}
