/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

namespace MouseScripts
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewRadius = 15;
        [Range(1, 360)] public float angle = 45;
        
        public LayerMask smuleLayer;
        public LayerMask obstacleLayer;
        public bool CanSeeSmule { get; set; }
        
        [HideInInspector] public List<Transform> visibleSmuler = new List<Transform>();

        private void Start()
        {
            StartCoroutine(FOVCheck(0.1f));
        }

        private IEnumerator FOVCheck(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleSmuler();
            }
        }
        
        private void FindVisibleSmuler()
        {
            visibleSmuler.Clear();
            int maxSmulerInView = 10;
            Collider[] smulerInViewRadius = new Collider[maxSmulerInView];
            var smulerInFOV = Physics.OverlapSphereNonAlloc(transform.position, viewRadius, smulerInViewRadius,
                smuleLayer);

            for (int i = 0; i < smulerInFOV; i++)
            {
                Transform smule = smulerInViewRadius[i].transform;
                Vector3 dirToSmule = (smule.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToSmule) < angle / 2)
                {
                    float distanceToSmule = Vector3.Distance(transform.position, smule.position);

                    if (!Physics.Raycast(transform.position, dirToSmule, distanceToSmule, obstacleLayer))
                    {
                        visibleSmuler.Add(smule);
                        Debug.Log("Smule Detected");
                        CanSeeSmule = true;
                    }
                    else
                    {
                        CanSeeSmule = false;
                    }
                }
            }
        }

        /*private void FOV()
        {
            Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetLayer);

            if (rangeCheck.Length > 0)
            {
                Transform target = rangeCheck[0].transform;
                Vector2 directionToTarget = (target.position - transform.position).normalized;

                if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector2.Distance(transform.position, target.position);
                    if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleLayer))
                    {
                        CanSeeSmule = true;
                    }
                    else
                    {
                        CanSeeSmule = false;
                    }
                }
                else CanSeeSmule = false;
            }
            else if (CanSeeSmule)
            {
                CanSeeSmule = false;
            }
        }#1#

        /*private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            var transform1 = transform;
            var position = transform1.position;
            var eulerAngles = transform1.eulerAngles;
            
            UnityEditor.Handles.DrawWireDisc(position, Vector3.forward, viewRadius);
           
            Vector3 angle01 = DirectionFromAngle(-eulerAngles.z, -angle / 2);
            Vector3 angle02 = DirectionFromAngle(-eulerAngles.z, angle / 2);
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(position, position  + angle01 * viewRadius);
            Gizmos.DrawLine(position, position  + angle02 * viewRadius);

            if (!CanSeeSmule) return;
            Gizmos.color = Color.green;
            foreach (var visibleSpawnArea in .visibleSpawnAreas)
            {
                Handles.DrawLine(fov.transform.position, visibleSpawnArea.position);
            }
        }#1#
        public Vector3 DirectionFromAngle(float eulerY, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                eulerY += transform.eulerAngles.y;
            }
            // angleInDegrees += eulerY;

            return new Vector3(Mathf.Sin(eulerY * Mathf.Deg2Rad), Mathf.Cos(eulerY * Mathf.Deg2Rad));
        }
    }
}*/
