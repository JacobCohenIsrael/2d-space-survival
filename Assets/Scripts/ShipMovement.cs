using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float decelerationFactor = 0.95f;

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var inputVector = gameInput.GetShipVectorNormalized();

        var horizontalInput = inputVector.x;
        var verticalInput = inputVector.y;
        
        transform.Rotate(Vector3.back * horizontalInput * speed);
        
        switch (verticalInput)
        {
            case > 0:
                rigidbody2D.AddForce(transform.up * speed);
                break;
            case < 0:
                rigidbody2D.AddForce(transform.up * -speed);
                break;
        }
        
        // if (verticalInput == 0)
        // {
        //     decelerationFactor = 0.95f;
        //     rigidbody2D.velocity *= decelerationFactor;
        //     if (rigidbody2D.velocity.magnitude < float.Epsilon)
        //     {
        //         rigidbody2D.velocity *= 0;
        //     }
        // }
    }
}
