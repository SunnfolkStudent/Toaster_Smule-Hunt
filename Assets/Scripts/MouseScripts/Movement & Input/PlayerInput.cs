using UnityEngine;

namespace MouseScripts.Movement___Input
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerControls _controls;
        private void Awake() => _controls = new PlayerControls();
        public void OnEnable() => _controls.Enable();
        public void OnDisable() => _controls.Disable();
        
        public void SwitchInputToGameScene()
        {
            _controls.TitleScreen.Disable();
            _controls.InGame.Enable();
        }
        
        public void SwitchInputToTitleScreen()
        {
            _controls.InGame.Disable();
            _controls.TitleScreen.Enable();
        }

        public Vector2 Movement { get; private set; }
        public static bool Interact;

        public static bool AnyKey;
        
        // Update is called once per frame
        void Update()
        {
            Movement = _controls.InGame.Movement.ReadValue<Vector2>();
            Interact = _controls.InGame.Interact.triggered;

            AnyKey = _controls.TitleScreen.AnyKey.triggered;
        }
    }
}
