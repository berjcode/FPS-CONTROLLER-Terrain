using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankShooter.Camera{
[CreateAssetMenu(menuName="Tank Shotter/Camera/Camera Settings")]
public class CameraSettings : ScriptableObject
{

    [Header("Rotation")]
    [SerializeField] private float _lerpSpeed =1;

   public float LerpSpeed {get {return _lerpSpeed;}}




  [Header("Position")]
  [SerializeField] private Vector3 _positionOffSet;
  public  Vector3 PositionOffSet {get {return _positionOffSet;}}


  [SerializeField] private float  _positionLerp = 1;
 public float PositionLerp {get {return _positionLerp;}}

   
}

}