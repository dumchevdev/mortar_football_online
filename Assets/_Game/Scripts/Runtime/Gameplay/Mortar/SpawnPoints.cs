using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Mortar
{
    public class SpawnPoints : MonoBehaviour
    {
        [field: SerializeField] public Transform MortarPosition { get; private set; }
        [field: SerializeField] public Transform GatePosition { get; private set; }
    }
}