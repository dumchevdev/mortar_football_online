using UnityEngine;
using Runtime._Game.Scripts.Runtime.Constants;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.AssetsService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.StaticDataService;
using Runtime._Game.Scripts.Runtime.Infrastructure.StaticData.UI;
using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Factories.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetService _assetService;
        private readonly StaticDataService _staticDataService;

        private Transform _uiRoot;

        public UIFactory(IAssetService assetService, StaticDataService staticDataService)
        {
            _assetService = assetService;
            _staticDataService = staticDataService;
        }

        UIElement IUIFactory.CreateScreen(UIElementType type)
        {
            ScreenInfo screenInfo = _staticDataService.GetUIElement(type);
            return Object.Instantiate(screenInfo.UIElement, _uiRoot).GetComponent<UIElement>();

        }

        void IUIFactory.CreateUIRoot()
        {
            var prefab = _assetService.GetPrefab(PathConstants.UIRootPath).transform;
            _uiRoot = Object.Instantiate(prefab);
        }
    }
}