using System.Collections;
using System.Collections.Generic;
using TankShooter.PlayerInput;
using UnityEngine;


namespace TankShooter.PlayerMovement {
public class PlayerMovementController : MonoBehaviour
{
   
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private InputData _inputData;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private PlayerMovementSettings _playerMovementSettings;

    void Update()
    {
        
         _rigidbody.MovePosition(_rigidbody.position + (_rigidbody.transform.forward * _inputData.Vertical * _playerMovementSettings.VerticalSpeed));
        _targetTransform.Rotate(0,_inputData.Horizontal*_playerMovementSettings.HorizontalSpeed,0,Space.Self);
    }
   
}

}
