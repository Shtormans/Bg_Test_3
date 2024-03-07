using Fusion;
using UnityEngine;
using static Unity.Collections.Unicode;

namespace Game
{
    public class WorldObserver : MonoBehaviour
    {
        [SerializeField] private TrackCreator _trackCreator;
        [SerializeField] private PlayerFabric _playerFabric;

        private NetworkRunner _networkRunner;
        private PlayerRef _playerRef;
        private PlayerCarController _playerCarController;

        public void SetNetworkParameters(NetworkRunner runner, PlayerRef playerRef)
        {
            _networkRunner = runner;
            _playerRef = playerRef;
        }

        public void PrepareGame()
        {
            _trackCreator.CreateTrack(_networkRunner);
        }

        public void StartCountdown()
        {
            var playerBehaviour = _playerFabric.CreatePlayer(_networkRunner, _playerRef);
            _playerCarController = _playerFabric.CreatePlayerCarController(_networkRunner, playerBehaviour);
            _playerCarController.enabled = false;
        }

        public void StartGame()
        {
            _playerCarController.SetCameraToItsPosition();
            _playerCarController.enabled = true;
        }
    }
}
