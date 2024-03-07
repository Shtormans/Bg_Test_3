using Helpers;
using ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPosition;
        [SerializeField] private WorldSettings _worldSettings;

        private List<float> _lines;
        private int _currentLine;
        private Rigidbody _rigidbody;

        public Transform CameraPosition => _cameraPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _lines = CustomMathFunctions
                .CalculateColumnPositions(_worldSettings.AmountOfObstacleColumns, _worldSettings.DistanceBetweenObstacleColumns)
                .Select(line => transform.position.z + line)
                .Reverse()
                .ToList();

            _currentLine = 0;

            ChangeLine(_currentLine);   
        }

        public void MoveStraight(float deltaTime)
        {
            var newPosition = transform.position + _worldSettings.CarSpeed * deltaTime * Vector3.right;
            transform.position = newPosition;
        }

        public void TryMoveLeft()
        {
            if (_currentLine - 1 < 0)
            {
                return;
            }

            _currentLine--;
            ChangeLine(_currentLine);
        }

        public void TryMoveRight()
        {
            if (_currentLine + 1 >= _lines.Count)
            {
                return;
            }

            _currentLine++;
            ChangeLine(_currentLine);
        }

        private void ChangeLine(int lineIndex)
        {
            Debug.Log(lineIndex);
            var nextPosition = transform.position;

            nextPosition.z = _lines[lineIndex];
            transform.position = nextPosition;
        }
    }
}
