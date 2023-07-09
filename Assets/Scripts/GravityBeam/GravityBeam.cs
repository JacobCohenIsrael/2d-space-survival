using PlayerResource;
using UnityEngine;
using UnityEngine.Events;

namespace GravityBeam
{
    public class GravityBeam : MonoBehaviour
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
                Resource resource = hit.collider.GetComponent<Resource>();
                if (resource != null)
                {
                    Rigidbody2D resourceRb = resource.GetComponent<Rigidbody2D>();
                    if (resourceRb != null)
                    {
                        var directionToShip = (Vector2)transform.position - (Vector2)resource.transform.position;
                        resourceRb.AddForce(directionToShip.normalized * attractionForce, ForceMode2D.Force);

                        var distanceToShip = directionToShip.magnitude;
                        if (distanceToShip <= pickupDistance)
                        {
                            resource.OnPickup();
                        }
                    }
                }
            }
        }

        public void StartPulling()
        {
            isAttracting = true;
            gravityBeamActiveEvent.Invoke(true);
        }

        public void StopPulling()
        {
            isAttracting = false;
            gravityBeamActiveEvent.Invoke(false);
        }
    }
}
