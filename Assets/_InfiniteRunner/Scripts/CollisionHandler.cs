using UnityEngine;
using UnityEngine.SceneManagement;

namespace _InfiniteRunner.Scripts
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private int mainSceneIndex;
        [SerializeField] private float loadDelayCrash = 1f;

        private void LoadMainScene()
        {
            SceneManager.LoadScene(mainSceneIndex);
        }

        private void Crash()
        {
            GetComponent<PlayerMover>().enabled = false;
            GetComponentInChildren<PlayerShooting>().enabled = false;
            FindObjectOfType<ScoreCounter>().CantCount();
            Invoke(nameof(LoadMainScene), loadDelayCrash);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.GetComponent<Enemy>() != null) Crash();
        }
    }
}
