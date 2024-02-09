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
            Handles.DrawWireArc(fovPosition, Vector3.up, Vector3.forward, 360, fov.viewRadius);
            Vector3 viewAngleA = fov.DirectionFromAngle(-fov.angle / 2, false);
            Vector3 viewAngleB = fov.DirectionFromAngle(fov.angle / 2, false);
            
            Handles.DrawLine(fovPosition, fovPosition + viewAngleA * fov.viewRadius);
            Handles.DrawLine(fovPosition, fovPosition + viewAngleB * fov.viewRadius);
            
            Handles.color = Color.red;
            foreach (var visibleSmule in fov.visibleSmuler)
            {
                Handles.DrawLine(fov.transform.position, visibleSmule.position);
            }
        }
    }
}*/
