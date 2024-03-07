using UnityEngine;

namespace MainMenu.Garage
{
    public class GarageCar : MonoBehaviour
    {
        [field: SerializeField] public Texture CarTexture { get; private set; }
        [field: SerializeField] public Transform Car { get; private set; }

        public void RotateHorizontal(float delta, float speed)
        {
            Car.transform.localEulerAngles += Vector3.up * delta * speed * Time.deltaTime;
        }
    }
}