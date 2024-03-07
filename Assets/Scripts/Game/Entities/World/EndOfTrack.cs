using UnityEngine;

namespace Game
{
    public class EndOfTrack : MonoBehaviour
    {
        [SerializeField] private StartPoint _startPoint;

        public Vector3 StartPoint => _startPoint.transform.position;
    }
}
