using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Mortar
{
    public class MortarBallisticTrajectory : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private int dotsCount;

        public void SetActiveLineRenderer(bool active)
        {
            lineRenderer.enabled = active;
        }
        
        public void ShowTrajectory(Vector3 startPosition, Vector3 velocity)
        {
            SetActiveLineRenderer(true);

            lineRenderer.positionCount = dotsCount;
            
            for(int i = 0; i < dotsCount; i++) 
            {
                float time = i * 0.1f;
                Vector3 pos = startPosition + velocity * time + Physics.gravity * time * time / 2f;
                
                lineRenderer.SetPosition(i, pos);
            }
        }
    }
}