using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float enginePower = 150.0f;
    public float power = 0.0f;
    public float brake = 0.0f;
    public float steer = 0.0f;
    public float maxSteer = 25.0f;
    public WheelCollider Wheel_LF;
    public WheelCollider Wheel_RF;
    public WheelCollider Wheel_LR;
    public WheelCollider Wheel_RR;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, -0.5f, 0.3f);
    }

    void Update()
    {
        power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime * 250.0f;
        steer = Input.GetAxis("Horizontal") * maxSteer;
        brake = Input.GetKey("space") ? GetComponent<Rigidbody>().mass * 0.1f : 0.0f;

        Wheel_LF.steerAngle = steer;
        Wheel_RF.steerAngle = steer;

        if (brake > 0.0)
        {
            Wheel_LF.brakeTorque = brake;
            Wheel_RF.brakeTorque = brake;
            Wheel_LR.brakeTorque = brake;
            Wheel_RR.brakeTorque = brake;
            Wheel_LR.motorTorque = 0.0f;
            Wheel_RR.motorTorque = 0.0f;
        }
        else
        {
            Wheel_LF.brakeTorque = 0;
            Wheel_RF.brakeTorque = 0;
            Wheel_LR.brakeTorque = 0;
            Wheel_RR.brakeTorque = 0;
            Wheel_LR.motorTorque = power;
            Wheel_RR.motorTorque = power;
        }
    }
}


