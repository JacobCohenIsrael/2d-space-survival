using System;
using UnityEngine;

namespace PlayerResource
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private ResourceType resourceType;

        public void OnPickup()
        {
            Destroy(gameObject);
        }
    }
}
