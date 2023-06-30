using System;
using UnityEngine;

namespace PlayerResource
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private ResourceType resourceType;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
