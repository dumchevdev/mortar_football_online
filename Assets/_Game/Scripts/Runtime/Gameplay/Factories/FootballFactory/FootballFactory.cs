using UnityEngine;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Factories.FootballFactory
{
    public class FootballFactory : IService
    {
        private readonly FootballPool _footballPool;

        public FootballFactory(FootballPool footballPool)
        {
            _footballPool = footballPool;
        }

        public GameObject CreateFootball(int playerId, int colorId, Vector3 spawnPoint)
        {
            var football = _footballPool.GetFootball();

            if (football != null)
            {
                football.SetupFootballToPlayer(playerId, colorId, spawnPoint);
                return football.gameObject;
            }
            
            return null;
        }
        
        public void ReturnToPool(int index)
        {
            _footballPool.ReturnToPool(index);
        }
    }
}