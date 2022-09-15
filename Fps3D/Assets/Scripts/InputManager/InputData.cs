using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankShooter.PlayerInput {
    [CreateAssetMenu(fileName ="Tank Shotter/Input/Input Data")]
    public class InputData : ScriptableObject
    {
         public float Horizontal;
        public float Vertical;


        [Header("Axis Base Control")]

        [SerializeField] private bool _AxisActive;
        public string AxisHorizontal;
        public string AxisNameVertical;

        [Header("Key Base Control")]
         [SerializeField] private bool _keyBaseHorizontalActive;
        public KeyCode PositiveHorizontalKeycode;
        public KeyCode NegativeHorizontalKeyCode; 

 [SerializeField] private bool _keyBaseVerticalActive;
        public KeyCode PositiVerticalKeycode;
        public KeyCode NegativeVerticalKeyCode; 


        public float LerpSpeed = 1;

        public void ProcessInput()
        {
            if(_AxisActive)
            {
                Horizontal = Input.GetAxis(AxisHorizontal);
                Vertical = Input.GetAxis(AxisNameVertical);
            }
            else 
            {
                if(_keyBaseHorizontalActive)
                {
                   KeyBaseHorizontal(ref Horizontal, PositiveHorizontalKeycode, NegativeHorizontalKeyCode);

                
                }
                if(_keyBaseVerticalActive)
                {
                    KeyBaseHorizontal(ref Vertical, PositiveHorizontalKeycode,NegativeVerticalKeyCode);
                }
            }
        }


        private void KeyBaseHorizontal(ref float value , KeyCode positive, KeyCode negative)
        {
            bool positiveActive = Input.GetKey(positive);
            bool negativeActive = Input.GetKey(negative);
             if(positiveActive && !negativeActive)
                    {
                        Horizontal = Mathf.Lerp(value,1,Time.time*LerpSpeed);
                    }
                    else if (negativeActive && !positiveActive)
                    {
                         Horizontal = Mathf.Lerp(value,-1,Time.time*LerpSpeed);
                    }else
                    {
                         Horizontal = Mathf.Lerp(value,0,Time.time*LerpSpeed);
                    }
           
        }
    
    }

}
