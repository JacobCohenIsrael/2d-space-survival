using System;
using JCI.Core.Events;
using JCI.Core.Models;
using UnityEngine;

namespace Gamefather.PlayerResource
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private GameEvent purpleResourceCollectedEvent;
        [SerializeField] private IntVar purpleResourceAmount;
        private void Awake()
        {
            if (purpleResourceCollectedEvent != null)
            {
                purpleResourceCollectedEvent.RegisterListener(OnPurpleResourceCollected);
            }
        }

        private void OnDestroy()
        {
            if (purpleResourceCollectedEvent != null)
            {
                purpleResourceCollectedEvent.UnregisterListener(OnPurpleResourceCollected);
            }
        }

        private void OnPurpleResourceCollected()
        {
            if (purpleResourceAmount != null)
            {
                purpleResourceAmount.Add(1, true);
            }
        }
    }
}
