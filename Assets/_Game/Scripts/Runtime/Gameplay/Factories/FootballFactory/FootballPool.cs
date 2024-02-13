using UnityEngine;
using Runtime._Game.Scripts.Runtime.Constants;
using Runtime._Game.Scripts.Runtime.Gameplay.Football;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Factories.FootballFactory
{
    public class FootballPool
    {
        private readonly FootballBehaviour[] _staticPool = new FootballBehaviour[16];
        
        public void Initialize()
        {
            for (int i = 0; i < 16; i++)
            {
                var football = Object.Instantiate(Game.AssetService.GetPrefab(PathConstants.FootballPath), Vector3.zero, Quaternion.identity);
                football.SetActive(false);
                
                var footballBehaviour = football.GetComponent<FootballBehaviour>();
                footballBehaviour.SetupPoolId(i);
                
                _staticPool[i] = footballBehaviour;
            }
        }

        public FootballBehaviour GetFootball()
        {
            foreach (var pool in _staticPool)
            {
                if (!pool.gameObject.activeSelf)
                {
                    return pool;
                }
            }

            return null;
        }

        public void ReturnToPool(int index)
        {
            var football = _staticPool[index].gameObject;
            football.SetActive(false);
        }
    }
}