using Photon.Pun;
using UnityEngine;
using Runtime._Game.Scripts.Runtime.Extensions;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Mortar
{
    public class MeshColorChanger : MonoBehaviour
    {
        private const string ChangeMeshColorRpcMethod = "ChangeMeshColor";
        
        [SerializeField] private PhotonView photonView;
        [SerializeField] private MeshRenderer meshRenderer;

        private int _colorId;

        public void ChangeColor(int colorId)
        {
            photonView.RPC(ChangeMeshColorRpcMethod, RpcTarget.AllViaServer, colorId);
        }
        
        [PunRPC] 
        public void ChangeMeshColor(int colorId)
        {
            meshRenderer.material.color = colorId.ToColorById();
        }
    }
}