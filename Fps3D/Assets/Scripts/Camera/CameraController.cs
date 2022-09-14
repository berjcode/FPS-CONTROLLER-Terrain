using System.Collections;
using System.Collections.Generic;
using TankShooter.Shooting;
using UnityEngine;

namespace TankShooter.Camera{
    public class CameraController : MonoBehaviour
    {
   
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _cameraTransform;
        public ShootingManager _shootingManager;

        void Update()
        {
             CameraRotationFollow();
             CameraMovementFollow();

             if(Input.GetKeyDown(KeyCode.Space))
             {
                _shootingManager.Shoot(_cameraTransform.position,_cameraTransform.forward);
             }

        }


        void CameraRotationFollow()
        {
                _cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation,
            Quaternion.LookRotation(_targetTransform.position - _cameraTransform.position),Time.deltaTime*_cameraSettings.LerpSpeed);
        }

        void CameraMovementFollow()
        {
            _cameraTransform.position = Vector3 .Lerp(_cameraTransform.position,_targetTransform.position
            + _cameraSettings.PositionOffSet,Time.deltaTime*_cameraSettings.PositionLerp);
        }


    }


}