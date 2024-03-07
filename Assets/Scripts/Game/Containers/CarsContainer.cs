using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CarsContainer : MonoBehaviour
    {
        [SerializeField] private List<PlayerCarController> _cars;

        public PlayerCarController GetPlayerCar()
        {
            return _cars[0];
        }
    }
}
