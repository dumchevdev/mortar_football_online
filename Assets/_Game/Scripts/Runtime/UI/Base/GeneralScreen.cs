using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.UI.Base
{
    public class GeneralScreen : UIElement
    {
        [field: SerializeField] public UIElementType UIElementType { get; private set; }
    }
}