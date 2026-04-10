using UnityEngine;

namespace _InfiniteRunner.Scripts
{
    public class Score : MonoBehaviour
    {
        protected int BestScore;
        
        protected void LoadScore()
        {
            BestScore = PlayerPrefs.GetInt("BestScore");
        }

        protected void SaveScore()
        {
            PlayerPrefs.SetInt("BestScore", BestScore);
        }
        
        protected void SetNewBestScore(int newBestScore)
        {
            if (BestScore < newBestScore)
            {
                BestScore = newBestScore;
                SaveScore();
            }
        }
    }
}
