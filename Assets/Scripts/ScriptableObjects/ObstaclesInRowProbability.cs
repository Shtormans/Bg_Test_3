using Game;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ObstaclesInRowProbability", menuName = "ScriptableObjects/ObstaclesInRowProbability")]
    public class ObstaclesInRowProbability : ScriptableObject
    {
        public int Amount;

        [Range(0f, 1f)] public float Probability;
    }
}
