using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Mortar
{
    public class MortarBehaviour : MonoBehaviour
    {
        [SerializeField] private MortarCamera mortarCamera;
        [SerializeField] private MortarBallisticTrajectory ballisticTrajectory;
        [SerializeField] private MortarShot mortarShot;
        [SerializeField] private MeshColorChanger colorChanger;
        
        public void SetupMortarToPlayer(int colorId)
        {
            mortarCamera.SetActiveCamera(true);
            ballisticTrajectory.SetActiveLineRenderer(false);
            
            mortarShot.enabled = true;

            colorChanger.ChangeColor(colorId);
        }
    }
}