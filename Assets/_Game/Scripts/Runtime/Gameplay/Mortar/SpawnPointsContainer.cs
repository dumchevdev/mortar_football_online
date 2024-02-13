using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Mortar
{
    public class SpawnPointsContainer : MonoBehaviour
    {
        [SerializeField] private SpawnPoints[] spawnPoints;
        
        public Vector3 GetMortarSpawnPoint(int index) => 
            spawnPoints[index].MortarPosition.transform.position;
        
        public Transform GetGateSpawnPoint(int index) => 
            spawnPoints[index].GatePosition.transform;
    }
}