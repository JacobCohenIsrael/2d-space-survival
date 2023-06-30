using Projectile;
using UnityEngine;

public class Health: MonoBehaviour, IProjectileTarget
{
    [SerializeField] private int health = 100;
    
    public void OnHit(ProjectileOrigin origin)
    {
        health--;
        if (health <= 0)
        {
            var spawner = GetComponent<ObjectSpawner>();
            if (spawner != null)
            {
                spawner.SpawnObjects();
            }
            Destroy(gameObject);
        }
    }
}