using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyGame.Core;
using MyGame.Core.Types;
using MyGame.Core.Signals;
using MyGame.UI.Views;
using deVoid.Utils;

namespace MyGame.UI.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] ResourcePool _resourcePool; 
        [SerializeField] Transform _itemsContainer;  
        [SerializeField] ResourceItemView _itemPrefab;
        [SerializeField] Button _resetButton;

        Dictionary<ResourceType, ResourceItemView> _spawnedItems = new Dictionary<ResourceType, ResourceItemView>();

        void Start()
        {
            SpawnInitialItems();
            _resetButton.onClick.AddListener(() => Signals.Get<ResourceResetSignal>().Dispatch());
        }

        void OnEnable()
        {
            Signals.Get<ResourceUpdatedSignal>().AddListener(UpdateAllItems);
            UpdateAllItems(); 
        }

        void OnDisable() => Signals.Get<ResourceUpdatedSignal>().RemoveListener(UpdateAllItems);

        void SpawnInitialItems()
        {
            foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType)))
            {
                ResourceItemView newItem = Instantiate(_itemPrefab, _itemsContainer);
                _spawnedItems.Add(type, newItem);
            }
            UpdateAllItems();
        }

        void UpdateAllItems()
        {
            if (_resourcePool == null) return;
            foreach (var kvp in _spawnedItems)
            {
                int currentAmount = _resourcePool.GetResourceAmount(kvp.Key);
                kvp.Value.Setup(kvp.Key.ToString(), currentAmount);
            }
        }
    }
}