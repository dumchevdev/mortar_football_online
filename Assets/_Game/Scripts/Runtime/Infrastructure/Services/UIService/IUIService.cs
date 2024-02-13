using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.UIService
{
    public interface IUIService : IService
    {
        public void InitUIRoot();
        public void Show(UIElementType type, object ctx);
        public UIElement Get(UIElementType type);
    }
}