using UnityEngine;

namespace Invaders
{
    internal sealed class GlobalGameParams
    {
        internal const string LevelNameTitle = "Level_{0}";
        internal static GlobalGameParams Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new GlobalGameParams();
                }
                return _instance;
            }
        }

        private static GlobalGameParams _instance;

        internal readonly float horizontalLimit;
        internal readonly float verticalLimit;


        private GlobalGameParams()
        {
            var pivotPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
            var offset = 1.15f;
            horizontalLimit = pivotPoint.x + offset;
            verticalLimit = pivotPoint.y + offset;
        }
    }
}
