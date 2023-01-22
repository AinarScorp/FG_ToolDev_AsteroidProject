using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Einar.ScriptableObjects
{

    [CreateAssetMenu(fileName = "Spawner Data", menuName = "Einar's/SpawnerData")]
    public class SpawnerData : ScriptableObject
    {
        [SerializeField] Asteroid asteroidPrefab;
        [SerializeField] float minSpawnTime;
        [SerializeField] float maxSpawnTime;
        [SerializeField] int minSpawnAmount;
        [SerializeField] int maxSpawnAmount;
        
        public float MinSpawnTime => minSpawnTime;
        public float MaxSpawnTime => maxSpawnTime;
        public int MinSpawnAmount => minSpawnAmount;
        public int MaxSpawnAmount => maxSpawnAmount;
        public Asteroid AsteroidPrefab => asteroidPrefab;

        public void SetMinSpawnTime(float newValue) => minSpawnTime = newValue;
        public void SetMaxSpawnTime(float newValue) => maxSpawnTime = newValue;
        public void SetMinSpawnAmount(int newValue) => minSpawnAmount = newValue;
        public void SetMaxSpawnAmount(int newValue) => maxSpawnAmount = newValue;
        public void SetAsteroidPrefab(Asteroid newValue) => asteroidPrefab = newValue;
    }

}