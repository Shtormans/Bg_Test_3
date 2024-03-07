using Fusion;
using UnityEngine;

namespace Game
{
    public abstract class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerBeahviour player))
            {
                OnPlayerTriggered(player);
            }
        }

        public abstract void OnPlayerTriggered(PlayerBeahviour player);
    }
}
