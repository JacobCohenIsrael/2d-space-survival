using Projectile;
using UnityEngine;

namespace Gamefather.Projectile
{
    public class ProjectileMovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private float accelerationSpeed = 100f;

        public ProjectileOrigin Origin { get; set; }

        private void Start()
        {
            rb2D.AddForce(transform.up * speed);
            Destroy(gameObject, 2f);
        }

        private void Update()
        {
            rb2D.AddForce(transform.up * Time.deltaTime * accelerationSpeed);

        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.gameObject.GetComponent<IProjectileTarget>();
            if (target != null)
            {
                target.OnHit(Origin);
                Destroy(gameObject);
            }
        }
    }
}