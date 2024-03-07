using Fusion;
using UnityEngine;

namespace Game
{
    public class PlayerFabric : MonoBehaviour
    {
        [SerializeField] private PlayerBeahviour _playerPrefab;
        [SerializeField] private CarsContainer _carsContainer;
        [SerializeField] private Camera _camera;

        public PlayerBeahviour CreatePlayer(NetworkRunner runner, PlayerRef playerRef)
        {
            var playerData = new PlayerData();

            var player = PlayerBeahviour.Builder.InstantiatePlayer(() =>
            {
                return runner.Spawn(_playerPrefab, inputAuthority: playerRef);
            }).AddPlayerData(playerData).Bake();

            return player;
        }

        public PlayerCarController CreatePlayerCarController(NetworkRunner runner, PlayerBeahviour playerBeahviour)
        {
            var playerCarController = PlayerCarController.Builder.InstantiatePlayer(() =>
            {
                var car = _carsContainer.GetPlayerCar();

                return runner.Spawn(car);
            }).AddPlayerBehaviour(playerBeahviour)
                .AddCamera(_camera)
                .Bake();

            return playerCarController;
        }
    }
}
