using System;
using UnityEngine;

public class WeaponModule : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private ProjectileMovement projectile;
    [SerializeField] private Transform projectileExitTransform;
    public void Fire()
    {
        if (fireRate > 0)
        {
            var projectileMovement = Instantiate(projectile, projectileExitTransform);
            projectileMovement.gameObject.transform.SetParent(null);
        }
    }
}
