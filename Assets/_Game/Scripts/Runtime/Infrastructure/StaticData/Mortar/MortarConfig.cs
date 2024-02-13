using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StaticData.Mortar
{
    [CreateAssetMenu(menuName = "StaticData/MortarConfig", fileName = "MortarConfig")]
    public class MortarConfig : ScriptableObject
    {
        [SerializeField] private int maxForce;
        [SerializeField] private int minForce;
        [SerializeField] private int maxHoldTime;
        
        public float CalculateHoldDownForce(float holdTime)
        {
            var holdTimeNormalized = Mathf.Clamp01(holdTime / maxHoldTime);
            return Mathf.Max(minForce, holdTimeNormalized * maxForce);
        }
    }
}