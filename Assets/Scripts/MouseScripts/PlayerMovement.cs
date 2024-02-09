using UnityEngine;

namespace MouseScripts
{
    [RequireComponent(typeof(PlayerController), typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private float moveSpeed = 5f;
        
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void UpdateMovement(Vector2 input)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + input.normalized * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}