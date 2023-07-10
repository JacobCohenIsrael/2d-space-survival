using System;
using System.Collections.Generic;
using Gamefather.GravityBeam;
using Projectile;
using UnityEngine;
using Weapon;

namespace Gamefather
{
    public class ShipWeaponsController : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.5f;
    
        [SerializeField] private GameInput gameInput;

        [SerializeField] private List<WeaponModule> weaponModules;

        [SerializeField] private GravityBeamController gravityBeamController;

        [SerializeField] private Rigidbody2D parentRigidBody;

        private bool isFiring;

        private bool isPulling;

        private float nextFireTime;
    
        private void Start()
        {
            gameInput.FireStartedEvent += OnFireStarted;
            gameInput.FireCanceledEvent += OnFireCanceled;

            gameInput.PullStartedEvent += OnPullStarted;
            gameInput.PullCanceledEvent += OnPullCanceled;
            nextFireTime = Time.time;
        }
    
        private void OnDestroy()
        {
            gameInput.FireStartedEvent -= OnFireStarted;
            gameInput.FireCanceledEvent -= OnFireCanceled;
        
            gameInput.PullStartedEvent -= OnPullStarted;
            gameInput.PullCanceledEvent -= OnPullCanceled;
        }

        private void Update()
        {
            if (isFiring && Time.time >= nextFireTime)
            {
                var initialVelocity = parentRigidBody.velocity;
                weaponModules.ForEach(weapon => weapon.Fire(ProjectileOrigin.Player, initialVelocity));
                nextFireTime = Time.time + fireRate;
            }
        }

        private void OnFireStarted(object sender, EventArgs e)
        {
            isFiring = true;
        }
    
        private void OnFireCanceled(object sender, EventArgs e)
        {
            isFiring = false;
        }

        private void OnPullStarted(object sender, EventArgs e)
        {
            gravityBeamController.StartPulling();
        }

        private void OnPullCanceled(object sender, EventArgs e)
        {
            gravityBeamController.StopPulling();
        }
    }
}
