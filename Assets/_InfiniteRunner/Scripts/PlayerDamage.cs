using UnityEngine;
using TMPro;

namespace _InfiniteRunner.Scripts
{
    public class PlayerDamage : MonoBehaviour, IPlayerDamage
    {
        [SerializeField] private int damage;
        [SerializeField] private TMP_Text damageText;

        private void LoadDamage()
        {
            damage = PlayerPrefs.GetInt("Damage");
        }

        private void SaveDamage()
        {
            PlayerPrefs.SetInt("Damage", damage);
        }

        private void UpdateUI()
        {
            damageText.text = damage.ToString();
        }

        public int GetPlayerDamage()
        {
            return damage;
        }
        
    }

    public interface IPlayerDamage
    {
        int GetPlayerDamage();
    }
    
}
