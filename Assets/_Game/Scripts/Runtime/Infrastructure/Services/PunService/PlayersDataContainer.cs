using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService
{
    public class PlayersDataContainer
    {
        public Dictionary<int, PlayerData> PlayersData { get; }

        public PlayerData LocalPlayerData => 
            PlayersData[PhotonNetwork.LocalPlayer.ActorNumber];

        public PlayersDataContainer()
        {
            PlayersData = new Dictionary<int, PlayerData>();
        }

        public void Clear() => 
            PlayersData.Clear();

        public void RemovePlayer(Player player)
        {
            if (PlayersData.TryGetValue(player.ActorNumber, out PlayerData _))
            {
                PlayersData.Remove(player.ActorNumber);
            }
        }

        public void AddPlayers(params Player[] players)
        {
            foreach (var player in players)
            {
                if (!PlayersData.TryGetValue(player.ActorNumber, out PlayerData playerData))
                {
                    playerData = new PlayerData(
                        player.ActorNumber, 
                        player.IsLocal, 
                        player.NickName);
                    
                    PlayersData[player.ActorNumber] = playerData;
                }
            }
        }
    }
}