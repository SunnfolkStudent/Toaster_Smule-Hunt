using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelScripts
{
    public class SceneController : MonoBehaviour
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
    }
}
