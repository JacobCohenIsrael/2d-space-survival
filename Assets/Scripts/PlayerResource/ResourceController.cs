using JCI.Core.Events;
using PlayerResource;
using UnityEngine;

namespace Gamefather.PlayerResource
{
    public class ResourceController : MonoBehaviour
    {
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private GameEvent resourceCollectedEvent;

        public void OnPickup()
        {
            if (resourceCollectedEvent != null)
            {
                resourceCollectedEvent.Raise();
            }
            else
            {
                Debug.LogError("No resource collected event attached");
            }
            Destroy(gameObject);
        }
    }
}
