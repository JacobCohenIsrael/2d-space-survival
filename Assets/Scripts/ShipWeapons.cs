using System;
using System.Collections.Generic;
using Projectile;
using UnityEngine;
using Weapon;

public class ShipWeapons : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    
    [SerializeField] private GameInput gameInput;

    [SerializeField] private List<WeaponModule> weaponModules;

    [SerializeField] private GravityBeam gravityBeam;

    [SerializeField] private Rigidbody2D parentRigidBody;

    private bool isFiring;

    private float nextFireTime;
    
    private void Start()
    {
        gameInput.FireStartedEvent += OnFireStarted;
        gameInput.FireCanceledEvent += OnFireCanceled;
        nextFireTime = Time.time;
    }

    private void Update()
    {
        if (isFiring)
        {
            gravityBeam.Attract();
        }
        if (isFiring && Time.time >= nextFireTime)
        {
            var initialVelocity = parentRigidBody.velocity;
            weaponModules.ForEach(weapon => weapon.Fire(ProjectileOrigin.Player, initialVelocity));
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDestroy()
    {
        gameInput.FireStartedEvent -= OnFireStarted;
        gameInput.FireCanceledEvent -= OnFireCanceled;
    }

    private void OnFireStarted(object sender, EventArgs e)
    {
        isFiring = true;
    }
    
    private void OnFireCanceled(object sender, EventArgs e)
    {
        isFiring = false;
    }
}
