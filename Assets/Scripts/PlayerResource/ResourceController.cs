using JCI.Core.Events;
using PlayerResource;
using UnityEngine;

namespace Gamefather.PlayerResource
{
    public class ResourceController : MonoBehaviour
    {
        public ResourceType resourceType;
        [SerializeField] private GameEventArg resourceCollectedEvent;

        public void OnPickup()
        {
            if (resourceCollectedEvent != null)
            {
                resourceCollectedEvent.Raise(this);
            }
            else
            {
                Debug.LogError("No resource collected event attached");
            }
        }
    }
}
