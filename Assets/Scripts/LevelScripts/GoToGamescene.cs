using LevelScripts;
using MouseScripts.Movement___Input;
using UnityEngine;

public class GoToGamescene : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _input.SwitchInputToTitleScreen();
    }

    private void Update()
    {
        if (PlayerInput.AnyKey)
        {
            _input.SwitchInputToGameScene();
            SceneController.LoadGameScene();
        }
    }
}
