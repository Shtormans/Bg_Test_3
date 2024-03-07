using Fusion;
using System;
using UnityEngine;

namespace Game
{
    public class PlayerBeahviour : NetworkBehaviour
    {
        private PlayerData _data;

        public class Builder
        {
            private PlayerBeahviour _player;

            private Builder() { }

            public static Builder InstantiatePlayer(Func<PlayerBeahviour> createFunction)
            {
                var playerBuilder = new Builder();
                playerBuilder._player = createFunction();

                return playerBuilder;
            }

            public Builder AddPlayerData(PlayerData data)
            {
                _player._data = data;

                return this;
            }

            public PlayerBeahviour Bake()
            {
                return _player;
            }
        }
    }
}
