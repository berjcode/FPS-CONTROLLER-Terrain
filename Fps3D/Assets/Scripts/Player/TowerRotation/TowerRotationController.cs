using System.Collections;
using System.Collections.Generic;
using TankShooter.PlayerInput;
using UnityEngine;


namespace TankShooter.PlayerMovement{
public class TowerRotationController : MonoBehaviour
{
    
    [SerializeField] private InputData _rotationInput;
    [SerializeField] private Transform _towerTransform;
    [SerializeField] private TowerRotationSettings _towerRotationSettings;



    void Update()
    {
        _towerTransform.Rotate(0,_rotationInput.Horizontal*_towerRotationSettings.TowerRotationSpeed,0,Space.Self);
    }

}

}