using UnityEngine;

namespace Gamefather
{
    public class ShipMovementController : MonoBehaviour
    {
        [SerializeField] private GameInput gameInput;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private float speed = 5f;

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            var inputVector = gameInput.GetShipVectorNormalized();

            var horizontalInput = inputVector.x;
            var verticalInput = inputVector.y;
        
            transform.Rotate(Vector3.back * horizontalInput * (speed / 2));
        
            switch (verticalInput)
            {
                case > 0:
                    rb2D.AddForce(transform.up * speed);
                    break;
                case < 0:
                    rb2D.AddForce(transform.up * -speed);
                    break;
            }
        }
    }
}
