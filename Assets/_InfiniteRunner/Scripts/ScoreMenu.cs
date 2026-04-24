using UnityEngine;
using TMPro;

namespace _InfiniteRunner.Scripts
{
    public class ScoreMenu : Score
    {
        [SerializeField] private TMP_Text scoreText;

        private void UpdateUI()
        {
            scoreText.text = BestScore.ToString();
        }

        private void Awake()
        {
            LoadScore();
            UpdateUI();
        }
        
    }
}
