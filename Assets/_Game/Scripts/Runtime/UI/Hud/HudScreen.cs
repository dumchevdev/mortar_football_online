using System.Linq;
using UnityEngine;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService;
using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.UI.Hud
{
    public class HudScreen : UIElement
    {
        public override UIElementType UIElementType => UIElementType.Hud;

        [SerializeField] private PlayerHudPanel[] playerPanels;

        private void OnEnable()
        {
            Game.GoalService.OnGoal += OnGoal;
            Game.PunService.OnPlayerLeftRoomEvent += UpdateOnPlayers;
        }
        
        private void OnDisable()
        {
            Game.GoalService.OnGoal -= OnGoal;
            Game.PunService.OnPlayerLeftRoomEvent -= UpdateOnPlayers;
        }

        protected override void OnShow(object ctx)
        {
            UpdateOnPlayers();
        }
        
        private void UpdateOnPlayers()
        {
            var players = Game.PunService.PlayersDataContainer.PlayersData.Values;

            int index = 0;
            foreach (PlayerData playerData in players)
            {
                playerPanels[index].Show(playerData);
                index++;
            }
            
            for (int i = players.Count; i < playerPanels.Length; i++)
            {
                playerPanels[i].Hide();
            }
        }

        private void OnGoal(int playerId)
        {
            var playerData = Game.PunService.PlayersDataContainer.PlayersData[playerId];
            var playerPanel = playerPanels.First(panel => panel.PlayerId == playerId);
            
            playerPanel.Show(playerData);
        }
    }
}