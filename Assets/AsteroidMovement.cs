using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private float decelerationFactor = 0.95f;
    [SerializeField] private Rigidbody2D rb2D;

    void FixedUpdate()
    {
        decelerationFactor = 0.95f;
        rb2D.velocity *= decelerationFactor;
        rb2D.angularVelocity *= decelerationFactor;
        if (rb2D.velocity.magnitude < float.Epsilon)
        {
            rb2D.angularVelocity *= 0;
            rb2D.velocity *= 0;
        }
    }
}
