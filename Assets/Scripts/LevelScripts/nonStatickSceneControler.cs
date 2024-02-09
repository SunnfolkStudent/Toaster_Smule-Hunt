using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelScripts
{
    public class nonStatickSceneController : MonoBehaviour
    {
        public void LoadTitleScreen()
        {
            SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
            
        }
        public void LoadScoreScreen()
        {
            SceneManager.LoadScene("ScoreScene", LoadSceneMode.Single);
        }
        public void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}