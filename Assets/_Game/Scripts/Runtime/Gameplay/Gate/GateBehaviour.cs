using Runtime._Game.Scripts.Runtime.Gameplay.Mortar;
using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Gate
{
    public class GateBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerId playerIdComponent;
        [SerializeField] private MeshColorChanger colorChanger;
        
        public void SetupGateToPlayer(int playerId, int colorId, Transform spawnTransform)
        {
            Transform gateTransform = transform;
            gateTransform.SetParent(spawnTransform);
            
            gateTransform.localPosition = Vector3.up*2;
            gateTransform.localRotation = Quaternion.identity;

            playerIdComponent.SetupPlayerId(playerId);
            
            colorChanger.ChangeColor(colorId);
        }
    }
}