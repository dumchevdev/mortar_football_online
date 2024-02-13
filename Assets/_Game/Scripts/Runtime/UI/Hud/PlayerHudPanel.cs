using TMPro;
using UnityEngine;
using Runtime._Game.Scripts.Runtime.Extensions;
using Runtime._Game.Scripts.Runtime.Gameplay.Gate;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService;

namespace Runtime._Game.Scripts.Runtime.UI.Hud
{
    public class PlayerHudPanel : MonoBehaviour
    {
        [SerializeField] private PlayerId playerId;
        [SerializeField] private TMP_Text nicknameText;
        [SerializeField] private TMP_Text scoreText;

        public int PlayerId => playerId.Id;

        public void Show(PlayerData playerData)
        {
            playerId.SetupPlayerId(playerData.Id);
            
            nicknameText.text = playerData.Nickname;
            scoreText.text = $"Score: {playerData.Score}";

            nicknameText.color = playerData.ColorId.ToColorById();
            scoreText.color = playerData.ColorId.ToColorById();
            
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}