using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StaticData.UI
{
    
    [CreateAssetMenu(menuName = "StaticData/ScreensConfig", fileName = "ScreensConfig")]
    public class ScreensConfig : ScriptableObject
    {
        [field: SerializeField] public ScreenInfo[] UIElementInfos { get; private set; }
    }
}