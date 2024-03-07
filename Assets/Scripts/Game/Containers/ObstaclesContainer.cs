using Helpers;
using ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class ObstaclesContainer : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectsContainer _scriptableObjectsContainer;

        private RandomChoiceObject<Obstacle>[] _obstaclesWithProbability;
        private List<Obstacle> _createdObjects = new();
        
        private void Awake()
        {
            _obstaclesWithProbability = _scriptableObjectsContainer.ObstaclesProbabilities.Select(item =>
            {
                return new RandomChoiceObject<Obstacle>(item.ObstaclePrefab, item.Probability);
            }).ToArray();
        }

        public Obstacle GetRandomObstacleByProbability()
        {
            return RandomChoiceMaker.MakeChoiceWithChances(_obstaclesWithProbability);
        }

        public void SaveNewObstacle(Obstacle obstacle)
        {
            _createdObjects.Add(obstacle);
        }
    }
}
