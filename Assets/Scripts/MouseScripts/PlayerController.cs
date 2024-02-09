using System;
using UnityEngine;

namespace MouseScripts
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerInput), typeof(PlayerAnimations))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerInput _playerInput;
        private PlayerAnimations _playerAnimations;
        
        void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerInput = GetComponent<PlayerInput>();
            _playerAnimations = GetComponent<PlayerAnimations>();
        }

        private void FixedUpdate()
        {
            _playerMovement.UpdateMovement(_playerInput.Movement);
            _playerAnimations.MouseAnimationUpdate(_playerInput.Movement);
        }
    }
}
