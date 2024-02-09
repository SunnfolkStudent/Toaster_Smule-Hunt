using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

namespace MouseScripts
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewRadius = 15;
        [Range(1, 360)] public float angle = 45;
        
        public LayerMask targetLayer;
        public LayerMask obstacleLayer;

        private GameObject _player;
        private bool CanSeeSmule { get; set; }

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(FOVCheck());
        }

        private IEnumerator FOVCheck()
        {
            WaitForSeconds wait = new WaitForSeconds(0.2f);

            while (true)
            {
                yield return wait;
                FOV();
            }
        }

        private void FOV()
        {
            Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetLayer);

            if (rangeCheck.Length > 0)
            {
                Transform target = rangeCheck[0].transform;
                Vector2 directionToTarget = (target.position - transform.position).normalized;

                if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector2.Distance(transform.position, target.position);

                    CanSeeSmule = !Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleLayer);
                }

                CanSeeSmule = false;
            }
            else if (CanSeeSmule)
            {
                CanSeeSmule = false;
            }
        }

        private void OnDrawGizmos()
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
            Gizmos.DrawLine(position, _player.transform.position);
        }
        private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;

            return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}
