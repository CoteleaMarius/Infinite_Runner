using UnityEngine;
using TMPro;

namespace _InfiniteRunner.Scripts
{
    public class ScoreCounter : Score
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private float scoreMultiplier;
        private bool _shouldCount = true;
        private float _score;

        private void Count()
        {
            _score += Time.deltaTime * scoreMultiplier;
            scoreText.text = Mathf.FloorToInt(_score).ToString();
        }

        private void Update()
        {
            if (!_shouldCount)
            {
                return;
            }
            Count();
        }

        public void CantCount()
        {
            _shouldCount = false;
            SetNewBestScore(Mathf.FloorToInt(_score));
        }
        
    }
}
