using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankShooter.PlayerInput {
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private  InputData _inputData;
        

        void Update()
        {
           _inputData.Horizontal =Input.GetAxis("Horizontal");
           _inputData.Vertical = Input.GetAxis("Vertical");
        }
    
    }
}


