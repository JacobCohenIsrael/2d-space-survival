using System;
using JCI.Core.Events;
using JCI.Core.Models;
using PlayerResource;
using UnityEngine;

namespace Gamefather.PlayerResource
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private IntVar purpleliumResourceAmount;
        [SerializeField] private IntVar blueriumResourceAmount;
        [SerializeField] private IntVar greeniumResourceAmount;

        private void Start()
        {
            purpleliumResourceAmount.SetAndNotify(0);
            blueriumResourceAmount.SetAndNotify(0);
            greeniumResourceAmount.SetAndNotify(0);
        }

        public void OnResourceCollected(ResourceController resourceController)
        {
            if (resourceController.resourceType == ResourceType.Purple &&  purpleliumResourceAmount != null)
            {
                purpleliumResourceAmount.Add(1, true);
            }
            
            if (resourceController.resourceType == ResourceType.Green &&  greeniumResourceAmount != null)
            {
                greeniumResourceAmount.Add(1, true);
            }
            
            if (resourceController.resourceType == ResourceType.Blue &&  blueriumResourceAmount != null)
            {
                blueriumResourceAmount.Add(1, true);
            }
            
            Destroy(resourceController.gameObject);
        }
    }
}
