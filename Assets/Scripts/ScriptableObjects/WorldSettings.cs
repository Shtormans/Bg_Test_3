using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "WorldSettings", menuName = "ScriptableObjects/WorldSettings")]
    public class WorldSettings : ScriptableObject
    {
        public float TimeToFinish;
        public float CarSpeed;
        public float CarTransitionSpeed;

        public float DistanceBetweenObstacles;
        public float StartSafeZone;
        public float EndSafeZone;

        public int AmountOfObstacleColumns;
        public float DistanceBetweenObstacleColumns;
    }
}
