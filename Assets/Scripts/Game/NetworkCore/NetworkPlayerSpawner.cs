using Fusion;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class NetworkPlayerSpawner : SimulationBehaviour, IPlayerJoined
    {
        [SerializeField] private TrackCreator _trackCreator;
        [SerializeField] private WorldObserver _worldObserver;
        [SerializeField] private PlayerFabric _playerFabric;

        public void PlayerJoined(PlayerRef player)
        {
            bool isPlayerAlone = Runner.ActivePlayers.Count() == 1;

            if (isPlayerAlone)
            {
                _worldObserver.PrepareGame();
            }

            if (player == Runner.LocalPlayer)
            {
                var playerBehaviour = _playerFabric.CreatePlayer(Runner, player);
                var playerCarController = _playerFabric.CreatePlayerCarController(Runner, playerBehaviour);
            }
        }
    }
}
