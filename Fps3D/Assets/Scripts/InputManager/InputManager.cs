using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankShooter.PlayerInput {
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private  InputData _inputData;
        [SerializeField] private InputData _rotationInputData;

        private Vector3 _lastMouseInput;
        

        void Update()
        {
           _inputData.Horizontal =Input.GetAxis("Horizontal");
           _inputData.Vertical = Input.GetAxis("Vertical");


           _rotationInputData.Horizontal = (Input.mousePosition.x - _lastMouseInput.x);
           _lastMouseInput = Input.mousePosition;

            _inputData.ProcessInput();
          
        }
    
    }
}


