using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Gate
{
    public class PlayerId : MonoBehaviour
    {
        public int Id { get; private set; }

        public void SetupPlayerId(int playerId)
        {
            Id = playerId;
        }
    }
}