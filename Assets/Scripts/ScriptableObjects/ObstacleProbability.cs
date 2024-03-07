using Game;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ObstacleProbability", menuName = "ScriptableObjects/ObstacleProbability")]
    public class ObstacleProbability : ScriptableObject
    {
        public Obstacle ObstaclePrefab;

        [Range(0f, 1f)] public float Probability;
    }
}
