using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainMenu.Garage
{
    public class GarageCarUI : MonoBehaviour, IDragHandler
    {
        [SerializeField] private RawImage _rawImage;
        [SerializeField] private float _rotationSpeed = 10;
        private GarageCar _car;

        public void SetData(GarageCar car, Texture texture)
        {
            _car = car;
            _rawImage.texture = texture;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var horizontalRotation = -eventData.delta.x;

            _car.RotateHorizontal(horizontalRotation, _rotationSpeed);
        }
    }
}
