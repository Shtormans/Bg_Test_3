using Fusion;
using Game;
using UnityEngine;

public class ObstaclesFabric : MonoBehaviour
{
    [SerializeField] private ObstaclesContainer _obstaclesContainer;

    public void InstantiateRandomObstacle(SpawnPoint spawnPoint, Track track, NetworkRunner runner)
    {
        var obstacle = _obstaclesContainer.GetRandomObstacleByProbability();

        obstacle = Instantiate(obstacle, spawnPoint.transform.position, Quaternion.identity);
        obstacle.transform.parent = track.transform;

        _obstaclesContainer.SaveNewObstacle(obstacle);
    }
}
