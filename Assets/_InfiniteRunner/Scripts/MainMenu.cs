using UnityEngine;
using UnityEngine.SceneManagement;

namespace _InfiniteRunner.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int indexLevelScene, indexInfiniteScene;

        private void SetActiveScene(int activeSceneIndex)
        {
            SceneManager.LoadScene(activeSceneIndex);
        }

        public void ActiveLevelScene()
        {
            SetActiveScene(indexLevelScene);
        }

        public void ActiveInfiniteScene()
        {
            SetActiveScene(indexInfiniteScene);
        }
        
    }
}
