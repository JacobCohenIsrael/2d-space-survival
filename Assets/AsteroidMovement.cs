using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private float decelerationFactor = 0.95f;
    [SerializeField] private Rigidbody2D rigidbody2D;

    void FixedUpdate()
    {
        decelerationFactor = 0.95f;
        rigidbody2D.velocity *= decelerationFactor;
        rigidbody2D.angularVelocity *= decelerationFactor;
        if (rigidbody2D.velocity.magnitude < float.Epsilon)
        {
            rigidbody2D.angularVelocity *= 0;
            rigidbody2D.velocity *= 0;
        }
    }
}
