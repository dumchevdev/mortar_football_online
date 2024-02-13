using System;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;
using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Services.InputService
{
    public interface IInputService : IService
    {
        public Vector3 Mouse { get; }
        public float HoldTime { get; }
        public event Action OnMouseButtonHolding;
        public event Action OnMouseButtonUp;
        public event Action OnEsc;
    }
}