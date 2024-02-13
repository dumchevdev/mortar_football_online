using System;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.UIService;
using Runtime._Game.Scripts.Runtime.UI.Base;
using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StaticData.UI
{
    [Serializable]
    public class ScreenInfo
    {
        [field: SerializeField] public UIElementType UIElementType { get; private set; }
        [field: SerializeField] public UIElement UIElement { get; private set; }
    }
}