using Unity.Mathematics;
using UnityEngine;

namespace MouseScripts
{
    public class PlayerAnimations : PlayerController
    {
        private PlayerInput _playerInput;
        
        public Animator anim;
        private Transform _transform;
    
        private string _direction;
        private Vector2 _directionValue;
        private Vector2 _lastPosition; 
    
        // Start is called before the first frame update
        private void Start()
        {
            _transform = GetComponent<Transform>();
        }

        // Update is called once per frame
        /*private void Update()
        {
            // Consider using Math.Sign to return a value of either -1, 0 or 1, and use that for animations.
            // Calculates direction from last-pos to current-pos
            var currentPosition = transform.position;
            var directionValue = ((Vector2)currentPosition - _lastPosition).normalized;
       
            // Updates last-pos for use in next Update() cycle
            _lastPosition = currentPosition;
            
            if (directionValue.y > Mathf.Sqrt(0.5f))
            {
                _direction = "_Up";
            }
            else if (directionValue.y < -Mathf.Sqrt(0.5f))
            {
                _direction = "_Down";
            } 
            else if (directionValue.x > Mathf.Sqrt(0.5f))
            {
                _direction = "_Right";
            }
            else if (directionValue.x < -Mathf.Sqrt(0.5f))
            {
                _direction = "_Left";
            }
            Animate(directionValue == Vector2.zero ? "Toes_Idle" : "Toes_Walk");
        }*/
    
        /*private void Animate(string unitAnimation)
        {
            anim.Play(unitAnimation + _direction);
        }*/
        
        private void MouseAnimationUpdate()
        {
            /*if (_playerInput.Movement.sqrMagnitude > 0.1)
            {
                anim.Play("walk");
            }
            else
            {
                anim.Play("idle",0);
            }*/

            switch (_playerInput.Movement)
            {
                case { x: 0, y: > 0 }:
                    _transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case { x: > 0, y: > 0 }:
                    _transform.eulerAngles = new Vector3(0, 0, -45);
                    break;
                case { x: > 0, y: 0 }:
                    _transform.eulerAngles = new Vector3(0, 0, -90);
                    break;
                case { x: > 0, y: < 0 }:
                    _transform.eulerAngles = new Vector3(0, 0, -135);
                    break;
                case { x: 0, y: < 0 }:
                    _transform.eulerAngles = new Vector3(0, 0, -180);
                    break;
                case { x: < 0, y: < 0 }:
                    _transform.eulerAngles = new Vector3(0, 0, -225);
                    break;
                case { x: < 0, y: 0 }:
                    _transform.eulerAngles = new Vector3(0, 0, -270);
                    break;
                case { x: < 0, y: > 0 }:
                    _transform.eulerAngles = new Vector3(0, 0, -315);
                    break;
            }

        }
    
    }
}
