using UnityEngine;
using System.Collections.Generic;

namespace _InfiniteRunner.Scripts
{
    public class InfinitePlatformSpawner : PlatformsSpawner
    {
        private Transform _playerTransform;
        private List<GameObject> _activePlatforms = new List<GameObject>();

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMover>().transform;
            GenerateStart();
        }

        protected override void SpawnPlatform(Platforms spawnPlatform)
        {
            GameObject newPlatform = Instantiate(spawnPlatform, transform.forward * SpawnDirection, 
                transform.rotation).gameObject;
            SpawnDirection += platformLength;
            _activePlatforms.Add(newPlatform);
        }

        private void RemoveActivePlatforms()
        {
            GameObject lostPlatform = _activePlatforms[0];
            _activePlatforms.RemoveAt(0);
            Destroy(lostPlatform);
        }

        private void Update()
        {
            if (_playerTransform.position.z > SpawnDirection - (maxPlatformsCount * platformLength))
            {
                SpawnPlatform(GetRandomPlatform());
                RemoveActivePlatforms();
            }
        }
        
    }
}
