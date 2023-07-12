using Gamefather.PlayerResource;
using JCI.Core.Events;
using UnityEngine.Events;

namespace Gamefather.Events
{
    public class ResourceCollectedEventListener : GameEventArgListener<ResourceController>
    {
        public UnityEventResource Response;
        
        protected override void Invoke(ResourceController castedObj)
        {
            Response.Invoke(castedObj);    
        }
    }
    
    [System.Serializable]
    public class UnityEventResource : UnityEvent<ResourceController>
    {
        
    }
}