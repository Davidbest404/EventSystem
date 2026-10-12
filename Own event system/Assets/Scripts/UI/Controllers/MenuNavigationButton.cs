using UnityEngine;
using UnityEngine.UI;
using MyGame.Core.Types;
using MyGame.Core.Signals;
using deVoid.Utils;

namespace MyGame.UI.Controllers
{
    [RequireComponent(typeof(Button))]
    public class MenuNavigationButton : MonoBehaviour
    {
        [SerializeField] MenuState _targetMenu;
        Button _button;

        void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        void OnDestroy() => _button.onClick.RemoveListener(OnClick);
        void OnClick() => deVoid.Utils.Signals.Get<MenuSwitchSignal>().Dispatch(_targetMenu);
    }
}