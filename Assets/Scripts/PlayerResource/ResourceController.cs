using PlayerResource;
using UnityEngine;

namespace Gamefather.PlayerResource
{
    public class ResourceController : MonoBehaviour
    {
        [SerializeField] private ResourceType resourceType;

        public void OnPickup()
        {
            Destroy(gameObject);
        }
    }
}
