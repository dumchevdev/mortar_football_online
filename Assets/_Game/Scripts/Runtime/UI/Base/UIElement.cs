using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.UI.Base
{
    public abstract class UIElement : MonoBehaviour
    {
        public virtual UIElementType UIElementType => UIElementType.None;
        
        public void Show(object context)
        {
            OnShow(context);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            OnHide();
            gameObject.SetActive(false);
        }
        
        protected virtual void OnShow(object context) {}
        protected virtual void OnHide() {}
    }
}