using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainMenu.Garage
{
    public class ScrollRectAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private HorizontalLayoutGroup _layoutGroup;
        [SerializeField] private float _animationDuration = 0.2f;

        private ScrollRect _scrollRect;
        private Coroutine _currentCoroutine;

        private void Awake()
        {
            _scrollRect = GetComponent<ScrollRect>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            int carIndex = FindClosestCar();

            if (carIndex != -1)
            {
                ScrollToImage(carIndex);
            }
        }

        private int FindClosestCar()
        {
            float minDistance = float.MaxValue;
            int closestCarIndex = -1;

            for (int i = 0; i < _layoutGroup.transform.childCount; i++)
            {
                var child = _layoutGroup.transform.GetChild(i);
                var scrollRectX = transform.position.x;
                var childX = child.transform.position.x;

                float distance = Mathf.Abs(scrollRectX - childX);
                Debug.Log(distance);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCarIndex = i;
                }
            }

            return closestCarIndex;
        }

        private void ScrollToImage(int targetIndex)
        {
            var targetPercentage = (float)targetIndex / (_layoutGroup.transform.childCount - 1);

            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(SmoothlyChangeScrollPosition(targetPercentage));
        }

        private IEnumerator SmoothlyChangeScrollPosition(float newPosition)
        {
            float startPosition = _scrollRect.normalizedPosition.x;
            float startTime = Time.time;

            while (Mathf.Abs(_scrollRect.normalizedPosition.x - newPosition) > 0.01f)
            {
                float t = (Time.time - startTime) / _animationDuration;
                float x = Mathf.SmoothStep(startPosition, newPosition, t);
                _scrollRect.normalizedPosition = new Vector2(x, 0);

                yield return null;
            }
        }
    }
}
