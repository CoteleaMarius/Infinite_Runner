using UnityEngine;

namespace _InfiniteRunner.Scripts
{
    public class PlatformsSpawner : MonoBehaviour
    {
        [SerializeField] protected Platforms[] platforms;
        [SerializeField] protected Platforms startPlatform;
        [SerializeField] protected int maxPlatformsCount;
        [SerializeField] protected float platformLength;
        protected float SpawnDirection;

        protected Platforms GetRandomPlatform()
        {
            int randomIndex = Random.Range(0, platforms.Length);
            return platforms[randomIndex];
        }

        protected virtual void SpawnPlatform(Platforms spawnPlatform)
        {
            Instantiate(spawnPlatform, transform.forward * SpawnDirection, transform.rotation);
            SpawnDirection += platformLength;
        }

        protected virtual void GenerateStart()
        {
            SpawnPlatform(startPlatform);
            for (int i = 0; i < maxPlatformsCount; i++)
            {
                SpawnPlatform(GetRandomPlatform());
            }
        }
        
    }
}
