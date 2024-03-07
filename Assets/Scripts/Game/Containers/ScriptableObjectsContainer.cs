using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ScriptableObjectsContainer : MonoBehaviour
    {
        [SerializeField] private List<ObstaclesInRowProbability> _obstaclesInRowProbability;
        [SerializeField] private List<ObstacleProbability> _obstaclesProbabilities;

        public IReadOnlyList<ObstaclesInRowProbability> ObstaclesInRowProbabilities => _obstaclesInRowProbability;
        public IReadOnlyList<ObstacleProbability> ObstaclesProbabilities => _obstaclesProbabilities;
    }
}
