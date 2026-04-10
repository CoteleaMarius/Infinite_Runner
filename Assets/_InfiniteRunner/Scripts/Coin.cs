using TMPro;
using UnityEngine;

namespace _InfiniteRunner.Scripts
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private TMP_Text addCoinText;
        [SerializeField] private AudioClip collectSound;
        [SerializeField] private int maxCoinCost;
        [SerializeField] private int minCoinCost;
        private int _coinCost;

        private void Start()
        {
            _coinCost = Random.Range(minCoinCost, maxCoinCost);
            addCoinText.text = _coinCost.ToString();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerMover>())
            {
                FindObjectOfType<Bank>().AddCoin(_coinCost);
                if (collectSound)
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                }
                Destroy(gameObject);
            }
        }
        
    }
}
