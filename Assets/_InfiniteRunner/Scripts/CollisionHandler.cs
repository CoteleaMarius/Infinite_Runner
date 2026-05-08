using UnityEngine;
using UnityEngine.SceneManagement;

namespace _InfiniteRunner.Scripts
{
    public class CollisionHandler : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        [SerializeField] private int mainSceneIndex;
        [SerializeField] private float loadDelayCrash = 1f;

        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        
        private void LoadMainScene()
        {
            SceneManager.LoadScene(mainSceneIndex);
        }

        private void Crash()
        {
            _animator.SetTrigger(Die);
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
