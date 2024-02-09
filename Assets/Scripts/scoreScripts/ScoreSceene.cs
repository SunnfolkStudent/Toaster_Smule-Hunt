using LevelScripts;
using MouseScripts.Movement___Input;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceene : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private PlayerInput _input;
    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _input.SwitchInputToTitleScreen();

        _text.text = scoreingAndDeactivating.score.ToString();
    }

    private void Update()
    {
        if (PlayerInput.AnyKey)
        {
            SceneController.LoadTitleScreen();
        }
    }
}
