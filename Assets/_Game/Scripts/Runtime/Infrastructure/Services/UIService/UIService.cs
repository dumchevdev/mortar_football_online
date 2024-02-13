using System.Collections.Generic;
using Runtime._Game.Scripts.Runtime.Infrastructure.Factories.UI;
using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.UIService
{
    public class UIService : IUIService
    {
        private readonly IUIFactory _uiFactory;
        
        private UIElement _activeUIElement;
        private readonly Dictionary<UIElementType, UIElement> _activatedUIElements;

        public UIService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _activatedUIElements = new Dictionary<UIElementType, UIElement>();
        }

        void IUIService.InitUIRoot()
        {
            _uiFactory.CreateUIRoot();
        }

        void IUIService.Show(UIElementType type, object ctx)
        {
            if (_activeUIElement != null)
            {
                _activeUIElement.Hide();
            }

            if (!_activatedUIElements.TryGetValue(type, out _activeUIElement))
            {
                _activeUIElement = _uiFactory.CreateScreen(type);
                _activatedUIElements.Add(type, _activeUIElement);
            }
            
            _activeUIElement.Show(ctx);
        }

        UIElement IUIService.Get(UIElementType type)
        {
            if (_activatedUIElements.TryGetValue(type, out var screen))
            {
                return screen;
            }

            return null;
        }
    }
}