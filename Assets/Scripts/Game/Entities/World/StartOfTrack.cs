using UnityEngine;

namespace Game
{
    public class StartOfTrack : MonoBehaviour
    {
        [SerializeField] private EndPoint _endPoint;

        public Vector3 EndPoint => _endPoint.transform.position;
    }
}
