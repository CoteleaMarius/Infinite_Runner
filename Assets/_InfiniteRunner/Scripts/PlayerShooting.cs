using UnityEngine;

namespace _InfiniteRunner.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(ParticleSystem))]
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private float distanceToShooting;
        private AudioSource _audioSource;
        private ParticleSystem _shootParticle;
        private ParticleSystem.EmissionModule _shootParticleEmission;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _shootParticle = GetComponent<ParticleSystem>();
            _shootParticleEmission = _shootParticle.emission;
        }

        private void Shoot()
        {
            _shootParticleEmission.enabled = true;

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }

        private void StopShoot()
        {
            _shootParticleEmission.enabled = false;
            _audioSource.Stop();
        }

        private void FixedUpdate()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            
            if(Physics.Raycast(transform.position, fwd, out hit, distanceToShooting, enemyLayer))
                Shoot();
            else
                StopShoot();
        }
    }
}
