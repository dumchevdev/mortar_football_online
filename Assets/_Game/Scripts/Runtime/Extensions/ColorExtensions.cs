using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Extensions
{
    public static class ColorExtensions
    {
        public static Color ToColorById(this int colorId)
        {
            return colorId switch
            {
                0 => Color.blue,
                1 => Color.red,
                2 => Color.green,
                3 => Color.magenta,
                4 => Color.yellow,
                5 => Color.white,
                6 => Color.cyan,
                _ => Color.black
            };
        }
    }
}