using UnityEngine;

namespace _InfiniteRunner.Scripts
{
    public class LevelPlatformsSpawner : PlatformsSpawner
    {
        [SerializeField] private Platforms finalPlatform;

        protected override void GenerateStart()
        {
            base.GenerateStart();
            SpawnPlatform(finalPlatform);
        }

        private void Start()
        {
            GenerateStart();
        }
        
    }
}
