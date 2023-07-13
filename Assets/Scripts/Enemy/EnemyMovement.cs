using UnityEngine;

namespace Gamefather.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public Transform targetTransform;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float orbitRadius = 2.5f;

        private void FixedUpdate()
        {
            var enemyTransform = transform;
            var distance = Vector2.Distance(targetTransform.position, enemyTransform.position);
            if (distance > orbitRadius)
            {
                rb2D.AddForce(enemyTransform.up * speed);
            }
        
            var targetDirection = targetTransform.position - enemyTransform.position;
            var desiredRotation = Quaternion.LookRotation(enemyTransform.forward, targetDirection.normalized);
        
            rb2D.MoveRotation(Quaternion.Lerp(enemyTransform.rotation, desiredRotation, speed * Time.fixedDeltaTime));

        }
    }
}
