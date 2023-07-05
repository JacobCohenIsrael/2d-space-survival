using Projectile;
using UnityEngine;

namespace Weapon
{
    public interface IWeapon
    {
        void Fire(ProjectileOrigin origin, Vector2 initialVelocity = default);
    }
}