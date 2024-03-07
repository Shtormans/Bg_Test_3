using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] private float _secondsToUsingTrafficLight = 3f;
        [SerializeField] private float _secondsToChangeTrafficLightColor = 1f;
        private float _secondsToCountdown;

        public event Action TimeOut;

        public void StartCountdown(float seconds)
        {
            StartCoroutine(AwaitForTimeOut());
        }

        private IEnumerator AwaitForTimeOut()
        {
            
        }
    }
}
