using UnityEngine;

namespace MouseScripts
{
    public class PlayerMovement : PlayerController
    {
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private float moveSpeed = 3f;
        
        private Vector2 _directionV2;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _directionV2.normalized * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}
