using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Mortar
{
    public class MortarCamera : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        public void SetActiveCamera(bool active)
        {
            mainCamera.gameObject.SetActive(active);
        }
    }
}