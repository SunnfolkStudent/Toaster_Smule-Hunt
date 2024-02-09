/*using UnityEditor;
using UnityEngine;

namespace MouseScripts
{
    [CustomEditor(typeof(FieldOfView))]
    public class FieldOfViewEditor : Editor
    {
        void OnSceneGUI()
        {
            FieldOfView fov = (FieldOfView)target;
            Handles.color = Color.magenta;
            var fovPosition = fov.transform.position;
            Handles.DrawWireArc(fovPosition, Vector2.up, Vector3.forward, 360, fov.viewRadius);
            Vector2 viewAngleA = fov.DirFromAngle(-fov.angle / 2, false);
            Vector2 viewAngleB = fov.DirFromAngle(fov.angle / 2, false);
            
            Handles.DrawLine(fovPosition, fovPosition + viewAngleA * fov.viewRadius);
            Handles.DrawLine(fovPosition, fovPosition + viewAngleB * fov.viewRadius);
            
            Handles.color = Color.red;
            foreach (var visibleSpawnArea in fov.visibleSpawnAreas)
            {
                Handles.DrawLine(fov.transform.position, visibleSpawnArea.position);
            }
        }
    }
}*/
