using Projectile;
using UnityEngine;

namespace Weapon
{
    public class WeaponModule : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private ProjectileMovement projectile;
        [SerializeField] private Transform projectileExitTransform;
        public void Fire(ProjectileOrigin origin, Vector2 initialVelocity = default)
        {
            if (fireRate > 0)
            {
                var projectileMovement = Instantiate(projectile, projectileExitTransform);
                projectileMovement.GetComponent<Rigidbody2D>().velocity = initialVelocity;
                projectileMovement.Origin = origin;
                projectileMovement.gameObject.transform.SetParent(null);
            }
        }
    }
}
