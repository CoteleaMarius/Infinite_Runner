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

        [SerializeField] private Animator animator;

        [SerializeField] private int coinsPerKill;
        
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
            animator.SetTrigger("Die");
            Invoke(nameof(DestroyEnemy), 2f);
            FindObjectOfType<Bank>().AddCoin(coinsPerKill);
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        
        private void TakeDamage(int damage)
        {
            animator.SetTrigger("Hit");
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

        public void Attack()
        {
            animator.SetTrigger("Attack");
        }
        
    }
}
