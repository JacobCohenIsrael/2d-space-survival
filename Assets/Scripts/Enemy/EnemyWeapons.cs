using System.Collections.Generic;
using Projectile;
using UnityEngine;
using Weapon;

namespace Enemy
{
    public class EnemyWeapons : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private List<WeaponModule> weaponModules;
    
    
        private float fireTimer = 0f; // Timer to track the time between shots

        private void Update()
        {
            // Increment the fire timer
            fireTimer += Time.deltaTime;

            // Check if enough time has passed to fire
            if (fireTimer >= fireRate)
            {
                FireWeapon();       // Fire the weapon
                fireTimer = 0f;     // Reset the timer
            }
        }

        private void FireWeapon()
        {
            weaponModules.ForEach(weapon => weapon.Fire(ProjectileOrigin.Enemy));
        }
    
    }
}