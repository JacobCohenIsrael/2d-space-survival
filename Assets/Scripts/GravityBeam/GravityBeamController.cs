using Gamefather.Attributes;
using Gamefather.PlayerResource;
using PlayerResource;
using UnityEngine;
using UnityEngine.Events;

namespace Gamefather.GravityBeam
{
    public class GravityBeamController : MonoBehaviour
    {
        [SerializeField] private UnityEvent<bool> gravityBeamActiveEvent; 

        public float maxDistance = 10f;  // Maximum distance at which resources can be affected
        public float attractionForce = 10f;  // Force applied to attract resources
        public float pickupDistance = 2f;  // Distance at which resources can be picked up
        public float coneAngle = 30f;  // Angle of the cone in degrees

        private bool isAttracting;
    
        private void FixedUpdate()
        {
            if (!isAttracting) return;
        
            // Cast a circle to detect nearby resources
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, maxDistance, transform.up, coneAngle, LayerMask.GetMask("Resource"));

            // Iterate through all the hits
            foreach (var hit in hits)
            {
                ResourceController resourceController = hit.collider.GetComponent<ResourceController>();
                if (resourceController != null)
                {
                    Rigidbody2D resourceRb = resourceController.GetComponent<Rigidbody2D>();
                    if (resourceRb != null)
                    {
                        var directionToShip = (Vector2)transform.position - (Vector2)resourceController.transform.position;
                        resourceRb.AddForce(directionToShip.normalized * attractionForce, ForceMode2D.Force);

                        var distanceToShip = directionToShip.magnitude;
                        if (distanceToShip <= pickupDistance)
                        {
                            resourceController.OnPickup();
                        }
                    }
                }
            }
        }

        [Button("Start Pulling")]
        public void StartPulling()
        {
            isAttracting = true;
            gravityBeamActiveEvent.Invoke(true);
        }

        [Button("Stop Pulling")]
        public void StopPulling()
        {
            isAttracting = false;
            gravityBeamActiveEvent.Invoke(false);
        }
    }
}
