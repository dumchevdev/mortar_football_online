using System.Collections.Generic;
using System.Linq;
using Runtime._Game.Scripts.Runtime.Constants;
using Runtime._Game.Scripts.Runtime.Infrastructure.StaticData.Mortar;
using Runtime._Game.Scripts.Runtime.Infrastructure.StaticData.UI;
using Runtime._Game.Scripts.Runtime.UI.Base;
using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.StaticDataService
{
    public class StaticDataService : IService
    {
        private Dictionary<UIElementType, ScreenInfo> _uiElementConfigs;

        public void Initialize()
        {
            MortarConfig = Resources.Load<MortarConfig>(PathConstants.StaticDataMortarPath);
            
            _uiElementConfigs = Resources
                .Load<ScreensConfig>(PathConstants.StaticDataUIPath)
                .UIElementInfos
                .ToDictionary(uiInfo => uiInfo.UIElementType, uiInfo => uiInfo);
        }

        public ScreenInfo GetUIElement(UIElementType type) =>
            _uiElementConfigs.TryGetValue(type, out ScreenInfo uiElement) 
                ? uiElement 
                : null;
        
        public MortarConfig MortarConfig { get; private set; }
    }
}