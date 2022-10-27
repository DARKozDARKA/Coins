using UnityEngine;

namespace CodeBase.Tools
{
    public class MapBorder : MonoBehaviour
    {
        public Vector3 MapCenter;
        public Vector2 MapSize;

        [HideInInspector]
        public Rect MapRect;
    
        [HideInInspector]
        public float MapHeight;
    }
}