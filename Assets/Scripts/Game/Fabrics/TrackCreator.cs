using Fusion;
using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TrackCreator : MonoBehaviour
    {
        [SerializeField] private WorldSettings _worldSettings;
        [SerializeField] private Track _track;
        [SerializeField] private StartOfTrack _startOfTrack;
        [SerializeField] private EndOfTrack _endOfTrack;
        [SerializeField] private ObstaclesFabric _obstaclesFabric;

        private NetworkRunner _runner;

        public void CreateTrack(NetworkRunner runner)
        {
            _runner = runner;

            ResizeTrack();
            LocateTrack();

            LocateEndOfTrack();

            FillTrack();
        }

        private void ResizeTrack()
        {
            float trackWidth = _worldSettings.TimeToFinish * _worldSettings.CarSpeed;

            var scale = _track.transform.localScale;
            scale.x = trackWidth;
            _track.transform.localScale = scale;

            _track.ResizeSpawnPoints(_worldSettings);
        }

        private void LocateTrack()
        {
            var trackOffset = _startOfTrack.EndPoint - _track.StartPoint;
            _track.transform.position = _track.transform.position + trackOffset;
        }

        private void LocateEndOfTrack()
        {
            var trackOffset = _track.EndPoint - _endOfTrack.StartPoint;
            _endOfTrack.transform.position = _endOfTrack.transform.position + trackOffset;
        }

        private void FillTrack()
        {
            foreach (var spawnPoint in _track.ObstacleSpawnPoints)
            {
                var position = spawnPoint.transform.position;

                _obstaclesFabric.InstantiateRandomObstacle(spawnPoint, _track, _runner);
            }
        }
    }
}
