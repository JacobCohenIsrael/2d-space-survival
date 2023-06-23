using System;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float accelerationSpeed = 100f;

    private void Start()
    {
        rb2D.AddForce(transform.up * speed);
    }

    private void Update()
    {
        rb2D.AddForce(transform.up * Time.deltaTime * accelerationSpeed);

    }
}