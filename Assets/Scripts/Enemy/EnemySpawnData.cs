using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu]
    public class EnemySpawnData : ScriptableObject
    {
        [SerializeField] 
        private SpawnEntry[] _entries;
        public IEnumerable<SpawnEntry> entries => _entries;

        
        public void Start()
        {
            TryGetEntryByTime(0, out var spawnEntry);
        }
        
        public bool TryGetEntryByTime(float time, out SpawnEntry spawnEntry)
        {
            float totalTime = 1;
			
            foreach (var entry in _entries)
            {

                totalTime += entry.Duration;
				
                if (totalTime > time)
                {
                    spawnEntry = entry;
                    return true;
                }

                var x = new SpawnEntry();
                var y = x;
            }

            spawnEntry = new SpawnEntry();
            return false;
        }
    }

    [System.Serializable]
    public struct SpawnEntry
    {
        [SerializeField] 
        private int _duration;
        public int Duration => _duration;

        [SerializeField] 
        private GameObject[] _prefabs;
        public GameObject[] Prefabs => _prefabs;

        [SerializeField] 
        private int _spawnCount;
        public int SpawnCount => _spawnCount;
    }
}
