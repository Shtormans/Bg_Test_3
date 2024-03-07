using Helpers;
using ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Track : MonoBehaviour
    {
        [SerializeField] private StartPoint _startPoint;
        [SerializeField] private EndPoint _endPoint;
        [SerializeField] private SpawnPoint _spawnPointPrefab;
        [SerializeField] private ScriptableObjectsContainer _scriptableObjectsContainer;

        private List<SpawnPoint> _obstacleSpawnPoints;

        public Vector3 StartPoint => _startPoint.transform.position;
        public Vector3 EndPoint => _endPoint.transform.position;
        public IReadOnlyList<SpawnPoint> ObstacleSpawnPoints => _obstacleSpawnPoints;

        public void ResizeSpawnPoints(WorldSettings worldSettings)
        {
            _obstacleSpawnPoints = new();
            var choiceObjects = _scriptableObjectsContainer.ObstaclesInRowProbabilities.Select(item =>
            {
                return new RandomChoiceObject<int>(item.Amount, item.Probability);
            }).ToArray();
            List<float> rowsPositions = CustomMathFunctions.CalculateColumnPositions(worldSettings.AmountOfObstacleColumns, worldSettings.DistanceBetweenObstacleColumns);

            float startPoint = StartPoint.x + worldSettings.StartSafeZone;
            float endPoint = EndPoint.x - worldSettings.EndSafeZone;
            float step = worldSettings.DistanceBetweenObstacles;

            for (float positionX = startPoint; positionX < endPoint; positionX += step)
            {
                int amountOfObstacles = GetAmountOfObstaclesInOneRow(choiceObjects);
                var positionsZ = PickPositions(amountOfObstacles, rowsPositions);

                for (int i = 0; i < amountOfObstacles; i++)
                {
                    var spawnPointPosition = new Vector3(transform.position.x + positionX, transform.position.y, positionsZ[i]);

                    var spawnPoint = Instantiate(_spawnPointPrefab, transform);
                    spawnPoint.transform.position = spawnPointPosition;

                    _obstacleSpawnPoints.Add(spawnPoint);
                }
            }
        }

        private List<float> PickPositions(int rowsAmount, List<float> rowsPositions)
        {
            var positions = RandomChoiceMaker.PickDifferentItems(rowsPositions.ToArray(), rowsAmount);

            return positions;
        }

        private int GetAmountOfObstaclesInOneRow(RandomChoiceObject<int>[] choiceObjects)
        {
            return RandomChoiceMaker.MakeChoiceWithChances(choiceObjects);
        }
    }
}
