using System;
using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Services.InputService
{
    public class InputServiceBehaviour : MonoBehaviour, IInputService
    {
        private const string MouseAxisY = "Mouse Y";
        private const string MouseAxisX = "Mouse X";
        
        public Vector3 Mouse { get; private set; }
        public float HoldTime { get; private set; }
        
        public event Action OnEsc;
        public event Action OnMouseButtonHolding;
        public event Action OnMouseButtonUp;
        
        private float _holdDownStartTime;
        
        private void Update()
        {
            Mouse += new Vector3(-Input.GetAxis(MouseAxisY), Input.GetAxis(MouseAxisX), 0);
            
            if (Input.GetMouseButtonDown(0))
            {
                _holdDownStartTime = Time.time;
            }

            if (Input.GetMouseButton(0))
            {
                HoldTime = Time.time - _holdDownStartTime;
                OnMouseButtonHolding?.Invoke();
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                HoldTime = Time.time - _holdDownStartTime;
                OnMouseButtonUp?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnEsc?.Invoke();
            }
        }
    }
}