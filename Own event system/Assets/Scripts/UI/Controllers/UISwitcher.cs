using System.Collections.Generic;
using UnityEngine;
using MyGame.Core.Types;
using MyGame.Core.Signals;
using deVoid.Utils;

namespace MyGame.UI.Controllers
{
    [System.Serializable]
    public struct MenuPanelMapping
    {
        public MenuState State;
        public GameObject PanelObject;
    }

    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] List<MenuPanelMapping> _menuPanels;
        [SerializeField] MenuState _startingMenu = MenuState.MainMenu;

        void OnEnable() => deVoid.Utils.Signals.Get<MenuSwitchSignal>().AddListener(OnMenuSwitch);
        void OnDisable() => deVoid.Utils.Signals.Get<MenuSwitchSignal>().RemoveListener(OnMenuSwitch);
        void Start() => SwitchMenu(_startingMenu);
        void OnMenuSwitch(MenuState targetMenu) => SwitchMenu(targetMenu);

        void SwitchMenu(MenuState targetMenu)
        {
            foreach (var mapping in _menuPanels)
            {
                if (mapping.PanelObject != null) mapping.PanelObject.SetActive(mapping.State == targetMenu);
            }
        }
    }
}