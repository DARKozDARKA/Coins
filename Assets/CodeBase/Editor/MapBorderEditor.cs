using CodeBase.Tools;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(MapBorder))]
    public sealed class MapBorderEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            MapBorder mapBorder = target as MapBorder;
            SetRect(mapBorder);
        
            EditorUtility.SetDirty(target);
        }

        private void SetRect(MapBorder mapBorder)
        {
            GetRectPoints(mapBorder,
                out var leftUpPoint,
                out var leftDownPoint, 
                out var rightUpPoint,
                out var rightDownPoint);

            Handles.color = Color.green;

            DrawLines(leftUpPoint, rightUpPoint, rightDownPoint, leftDownPoint);
            SetBorderValues(mapBorder, leftDownPoint);
        }

        private void GetRectPoints(MapBorder border, out Vector3 leftUpPoint, out Vector3 leftDownPoint,
            out Vector3 rightUpPoint, out Vector3 rightDownPoint)
        {
            var xMax = border.MapCenter.x + border.MapSize.x;
            var yMax = border.MapCenter.z + border.MapSize.y;
            var xMin = border.MapCenter.x - border.MapSize.x;
            var yMin = border.MapCenter.z - border.MapSize.y;

            leftUpPoint = new Vector3(xMin, border.MapCenter.y, yMax);
            leftDownPoint = new Vector3(xMin, border.MapCenter.y, yMin);
            rightUpPoint = new Vector3(xMax, border.MapCenter.y, yMax);
            rightDownPoint = new Vector3(xMax, border.MapCenter.y, yMin);
        }

        private void DrawLines(Vector3 leftUpPoint, Vector3 rightUpPoint, Vector3 rightDownPoint, Vector3 leftDownPoint)
        {
            Handles.DrawLine(leftUpPoint, rightUpPoint);
            Handles.DrawLine(rightUpPoint, rightDownPoint);
            Handles.DrawLine(rightDownPoint, leftDownPoint);
            Handles.DrawLine(leftDownPoint, leftUpPoint);
            Handles.DrawLine(leftDownPoint, rightUpPoint);
            Handles.DrawLine(rightDownPoint, leftUpPoint);
        }

        private void SetBorderValues(MapBorder mapBorder, Vector3 leftDownPoint)
        {
            mapBorder.MapRect = new Rect(leftDownPoint.x, leftDownPoint.z, mapBorder.MapSize.x * 2, mapBorder.MapSize.y * 2);
            mapBorder.MapHeight = mapBorder.MapCenter.y;
        }
    }
}
