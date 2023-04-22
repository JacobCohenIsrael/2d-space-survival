using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private ShipMovement shipMovement;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float orbitRadius = 2.5f;

    private void FixedUpdate()
    {
        var distance = Vector2.Distance(shipMovement.transform.position, transform.position);
        Debug.Log(distance);
        if (distance > orbitRadius)
        {
            rigidbody2D.AddForce(transform.up * speed);
        }
        
        var targetDirection = shipMovement.transform.position - transform.position;
        var desiredRotation = Quaternion.LookRotation(transform.forward, targetDirection.normalized);
        
        rigidbody2D.MoveRotation(Quaternion.Lerp(transform.rotation, desiredRotation, speed * Time.fixedDeltaTime));

    }
}
