using UnityEngine;
using TMPro;

namespace _InfiniteRunner.Scripts
{
    public class Enemy : MonoBehaviour
    {
        private IPlayerDamage _playerDamage;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;

        private void UpdateUI()
        {
            healthText.text = currentHealth.ToString();
        }

        private void RecalculateHp()
        {
            currentHealth = maxHealth;
            UpdateUI();
        }

        private void Awake()
        {
            RecalculateHp();
            _playerDamage = FindObjectOfType<PlayerDamage>().GetComponent<IPlayerDamage>();
        }

        private void Die()
        {
            GetComponent<Collider>().enabled = false;
        }

        private void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
            UpdateUI();
        }

        private void OnParticleCollision(GameObject other)
        {
            TakeDamage(_playerDamage.GetPlayerDamage());
        }
        
    }
}
