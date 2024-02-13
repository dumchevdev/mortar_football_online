using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Factories.UI
{
    public interface IUIFactory
    {
        public void CreateUIRoot();
        public UIElement CreateScreen(UIElementType type);
    }
}