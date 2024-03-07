using Fusion;
using System;
using UnityEngine;

namespace Game
{
    public class PlayerCarController : NetworkBehaviour, IBeforeUpdate
    {
        private CarController _carController;
        private PlayerBeahviour _playerBeahviour;
        private InputHandler _inputHandler;
        private Camera _camera;
        private MovementType _movementType;

        public override void Spawned()
        {
            _carController = GetComponent<CarController>();

#if UNITY_EDITOR
            _inputHandler = new KeyboardInputHandler();
#elif UNITY_ANDROID
            _inputHandler = new AndroidInputHandler();
#endif
        }

        public void BeforeUpdate()
        {
            _movementType = _inputHandler.GetMovementType();
        }

        public override void FixedUpdateNetwork()
        {
            _carController.MoveStraight(Runner.DeltaTime);
            HandleMovement(_movementType);
        }

        public void SetCameraToItsPosition()
        {
            var newCameraPositionAndRotation = _carController.CameraPosition;
            _camera.transform.SetPositionAndRotation(newCameraPositionAndRotation.position, newCameraPositionAndRotation.rotation);
        }

        private void HandleMovement(MovementType type)
        {
            if (type == MovementType.None)
            {
                return;
            }

            if (type == MovementType.MoveLeft)
            {
                _carController.TryMoveLeft();
            }
            else if (type == MovementType.MoveRight)
            {
                _carController.TryMoveRight();
            }

            _movementType = MovementType.None;
        }

        public class Builder
        {
            private PlayerCarController _player;

            private Builder() { }

            public static Builder InstantiatePlayer(Func<PlayerCarController> createFunction)
            {
                var playerBuilder = new Builder();
                playerBuilder._player = createFunction();

                return playerBuilder;
            }

            public Builder AddCamera(Camera camera)
            {
                camera.transform.parent = _player.transform;
                _player._camera = camera;

                return this;
            }

            public Builder AddPlayerBehaviour(PlayerBeahviour playerBehaviour)
            {
                _player._playerBeahviour = playerBehaviour;

                return this;
            }

            public PlayerCarController Bake()
            {
                return _player;
            }
        }
    }
}
