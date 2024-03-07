using System;
using UnityEngine;

namespace Game
{
    public class TrafficLight : MonoBehaviour
    {
        private Action _nextState;

        private void OnEnable()
        {
            SetColorToRed();
        }

        public void ChangeState()
        {
            _nextState?.Invoke();
        }

        private void SetColorToRed()
        {
            _nextState = SetColorToYellow;
        }

        private void SetColorToYellow()
        {
            _nextState = SetColorToGreen;
        }

        private void SetColorToGreen()
        {
            _nextState = null;
        }
    }
}
