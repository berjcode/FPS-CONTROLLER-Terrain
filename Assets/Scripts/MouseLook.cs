using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public PlayerController playerScript;

    [Range(50, 500)]
    public float sens;
    public Transform body;

    float xRot = 0f;
    //RÝGHT LEFT LOOK
    public Transform leaner;
    public float zRot;
    bool isRotating;

    //head 
    public float smoothing;
    float currentRot;
    bool canRotate = true;

    //joystick

    public FixedJoystick joystick;
    private void Start()
    {
       /* Cursor.visible = false;
        Cursor.lockState= CursorLockMode.Locked; 
       */
    }
    private void Update()
    {
        float Rotx= joystick.Horizontal * sens *Time.deltaTime;
        float RotY= joystick.Vertical * sens *Time.deltaTime;
        xRot -= RotY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);
        //head
        currentRot += Rotx;
        currentRot = Mathf.Lerp(currentRot, 0, smoothing * Time.deltaTime);

        if(canRotate)
        {
            transform.localRotation = Quaternion.Euler(xRot, 0f, currentRot);
            body.Rotate(Vector3.up * Rotx);
        }
        

      
       

        //Right Left

        if(Input.GetKey(KeyCode.E))
        {
            zRot = Mathf.Lerp(zRot, -20.0f, 5f * Time.deltaTime);
            isRotating = true;
            canRotate = false;
            playerScript.canMove = false;
            

        }

        if(Input.GetKey(KeyCode.Q))
        {
            zRot = Mathf.Lerp(zRot, 20.0f, 5f * Time.deltaTime);
            isRotating = true;
            canRotate = false;
            playerScript.canMove = false;

        }

        if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            isRotating = false;
            canRotate = true;
            playerScript.canMove = true;
        }

        if(!isRotating)
            zRot= Mathf.Lerp(zRot, 0.0f,5f*Time.deltaTime);



        leaner.localRotation = Quaternion.Euler(0, 0, zRot);
    }




}
