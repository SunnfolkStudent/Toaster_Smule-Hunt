using UnityEngine.SceneManagement;

namespace LevelScripts
{
    public static class SceneController
    {
        public static void LoadTitleScreen()
        {
            SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
        }
        public static void LoadScoreScreen()
        {
            SceneManager.LoadScene("ScoreScene", LoadSceneMode.Single);
        }
        public static void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
    }
}
