using System.Collections.Generic;
using UnityEngine;
using MyGame.Core.Types;
using MyGame.Core.Signals;
using deVoid.Utils;

namespace MyGame.Core
{
    public class ResourcePool : MonoBehaviour
    {
        Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>();

        void Awake()
        {
            foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType))) _resources[type] = 0;
        }

        void OnEnable()
        {
            deVoid.Utils.Signals.Get<ResourceModifierSignal>().AddListener(OnResourceModified);
            deVoid.Utils.Signals.Get<ResourceResetSignal>().AddListener(OnResourceReset);
        }

        void OnDisable()
        {
            deVoid.Utils.Signals.Get<ResourceModifierSignal>().RemoveListener(OnResourceModified);
            deVoid.Utils.Signals.Get<ResourceResetSignal>().RemoveListener(OnResourceReset);
        }

        void OnResourceModified(ResourceType type, int amount, bool isAdding)
        {
            if (isAdding) _resources[type] += amount;
            else
            {
                _resources[type] -= amount;
                if (_resources[type] < 0) _resources[type] = 0; 
            }
            deVoid.Utils.Signals.Get<ResourceUpdatedSignal>().Dispatch();
        }

        void OnResourceReset()
        {
            List<ResourceType> keys = new List<ResourceType>(_resources.Keys);
            foreach (var key in keys) _resources[key] = 0;
            deVoid.Utils.Signals.Get<ResourceUpdatedSignal>().Dispatch();
        }
        public int GetResourceAmount(ResourceType type)
        {
            return _resources.ContainsKey(type) ? _resources[type] : 0;
        }
    }
}