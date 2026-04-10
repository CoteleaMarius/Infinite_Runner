using UnityEngine;
using TMPro;

namespace _InfiniteRunner.Scripts
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentCoinCountText;
        private int _currentCoinCount;
        private readonly string _prefsCoinKey = "CurrentCoinCount";

        private void UpdateUI()
        {
            currentCoinCountText.text = _currentCoinCount.ToString();
        }

        private void LoadCointCount()
        {
            _currentCoinCount = PlayerPrefs.GetInt(_prefsCoinKey);
        }

        private void SaveCoinCount()
        {
            PlayerPrefs.SetInt(_prefsCoinKey, _currentCoinCount);
        }

        public void AddCoin(int addCoin)
        {
            _currentCoinCount += addCoin;
            UpdateUI();
            SaveCoinCount();
        }

        public bool CanSpend(int spendCoinCount)
        {
            if (_currentCoinCount - spendCoinCount >= 0)
            {
                _currentCoinCount -= spendCoinCount;
                UpdateUI();
                SaveCoinCount();
                return true;
            }

            return false;
        }

        private void Awake()
        {
            LoadCointCount();
            UpdateUI();
        }
        
    }
}
