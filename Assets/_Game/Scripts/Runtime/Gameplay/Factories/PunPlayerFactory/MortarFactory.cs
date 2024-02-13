using Photon.Pun;
using Runtime._Game.Scripts.Runtime.Constants;
using Runtime._Game.Scripts.Runtime.Gameplay.Mortar;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService;
using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Factories.PunPlayerFactory
{
    public class MortarFactory : IService
    {
        private readonly SpawnPointsContainer _spawnPointsContainer;

        public MortarFactory(SpawnPointsContainer spawnPointsContainer)
        {
            _spawnPointsContainer = spawnPointsContainer;
        }

        public void CreatePlayer()
        {
            var playerData = Game.PunService.PlayersDataContainer.LocalPlayerData;
            
            var mortar = PhotonNetwork.Instantiate(PathConstants.PlayerPath, 
                _spawnPointsContainer.GetMortarSpawnPoint(playerData.Id-1), Quaternion.identity);
            
            mortar.GetComponent<MortarBehaviour>().SetupMortarToPlayer(playerData.ColorId);
        }
    }
}