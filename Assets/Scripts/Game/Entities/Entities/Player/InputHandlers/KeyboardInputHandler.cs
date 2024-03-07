using UnityEngine;

namespace Game
{
    public class KeyboardInputHandler : InputHandler
    {
        public override MovementType GetMovementType()
        {
            var movementType = MovementType.None;

            if (Input.GetKeyDown(KeyCode.A))
            {
                movementType = MovementType.MoveLeft;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                movementType = MovementType.MoveRight;
            }

            return movementType;
        }
    }
}
