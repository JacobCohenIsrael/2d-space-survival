using Projectile;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gamefather.Projectile
{
    public class ProjectileMovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float homingSpeed = 15f;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private float accelerationSpeed = 100f;
        [SerializeField] private ProjectileType type;
        [SerializeField] private float searchRadius = 20f;
        [SerializeField] private float timeToFly = 2f;
        [SerializeField] private string homingMask;

        public ProjectileOrigin Origin { get; set; }
        

        public Transform target;

        private void Start()
        {
            if (type == ProjectileType.Homing)
            {
                target = FindNearestEnemy();
                timeToFly *= 5;
                speed /= 5;
                accelerationSpeed /= 2;
            }
            rb2D.AddForce(transform.up * speed);

            Destroy(gameObject, timeToFly);
        }


        private void FixedUpdate()
        {
            rb2D.AddForce(transform.up * Time.fixedDeltaTime * accelerationSpeed);
            if (type == ProjectileType.Homing && target != null)
            {
                var projectileTransform = transform;
                var distance = Vector2.Distance(target.position, projectileTransform.position);
        
                var targetDirection = target.position - projectileTransform.position;
                var desiredRotation = Quaternion.LookRotation(projectileTransform.forward, targetDirection.normalized);
        
                rb2D.MoveRotation(Quaternion.Lerp(projectileTransform.rotation, desiredRotation, homingSpeed * Time.fixedDeltaTime));
            }
        }

        private Transform FindNearestEnemy()
        {
            searchRadius = 20f; // Adjust the search radius as needed
            LayerMask targetMask = LayerMask.GetMask(homingMask); // Specify the enemy layer name

            var colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius, targetMask);

            Transform nearestEnemy = null;
            var closestDistance = Mathf.Infinity;
            var currentPosition = transform.position;

            foreach (var col in colliders)
            {
                var directionToEnemy = col.transform.position - currentPosition;
                var distance = directionToEnemy.sqrMagnitude;

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestEnemy = col.transform;
                }
            }

            return nearestEnemy;
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