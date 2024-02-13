using System;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Services.GoalService
{
    public class GoalService : IService
    {
        public event Action<int> OnGoal;

        public void Goal(int playerId, int score)
        {
            var playerData = Game.PunService.PlayersDataContainer.PlayersData[playerId];
            playerData.UpdateScore(score);
            
            OnGoal?.Invoke(playerId);
        }
    }
}