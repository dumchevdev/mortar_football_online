using UnityEngine;
using System.Collections;
using Runtime._Game.Scripts.Runtime.Extensions;
using Runtime._Game.Scripts.Runtime.Gameplay.Gate;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Football
{
    public class FootballBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerId playerIdComponent;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Rigidbody footballRigidbody;
        
        public int PoolId { get; private set; }

        public void SetupPoolId(int id)
        {
            PoolId = id;
        }

        public void SetupFootballToPlayer(int playerId, int colorId, Vector3 spawnPoint)
        {
            transform.position = spawnPoint;
            footballRigidbody.velocity = Vector3.zero;

            playerIdComponent.SetupPlayerId(playerId);
            
            meshRenderer.material.color = colorId.ToColorById();
            
            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            StartCoroutine(ReturnToPool());
        }

        private IEnumerator ReturnToPool()
        {
            yield return new WaitForSeconds(3);
            
            Game.FootballFactory.ReturnToPool(PoolId);
        }
    }
}