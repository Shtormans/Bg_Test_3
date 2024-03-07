using UnityEngine;

namespace Game
{
    public class AndroidInputHandler : InputHandler
    {
        private Vector2 _startTouchPosition;

        public override MovementType GetMovementType()
        {
            if (Input.touchCount == 0)
            {
                return MovementType.None;
            }

            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPosition = touch.position;
                return MovementType.None;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Vector2 direction = touch.position - _startTouchPosition;

                return ChooseMovement(direction);
            }

            return MovementType.None;
        }

        private MovementType ChooseMovement(Vector2 direction)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    return MovementType.MoveRight;
                }
                else
                {
                    return MovementType.MoveLeft;
                }
            }

            return MovementType.None;
        }
    }
}
