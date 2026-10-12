using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using MyGame.Core.Types;
using MyGame.Core.Signals;

namespace MyGame.UI.Controllers
{
    public class AddMenuController : MonoBehaviour
    {
        [SerializeField] TMP_Dropdown _resourceDropdown;
        [SerializeField] TMP_InputField _amountInputField;
        [SerializeField] Button _actionButton;

        private void Start()
        {
            AutoFillDropdown();
            _actionButton.onClick.AddListener(OnActionButtonClicked);
        }

        private void AutoFillDropdown()
        {
            _resourceDropdown.ClearOptions();
            List<string> options = new List<string>(System.Enum.GetNames(typeof(ResourceType)));
            _resourceDropdown.AddOptions(options);
        }

        private void OnActionButtonClicked()
        {
            if (int.TryParse(_amountInputField.text, out int amount))
            {
                ResourceType selectedResource = (ResourceType)_resourceDropdown.value;
                deVoid.Utils.Signals.Get<ResourceModifierSignal>().Dispatch(selectedResource, amount, true);
                _resourceDropdown.value = 0;
                _amountInputField.text = "";
            }
            else Debug.LogWarning("Введите корректное число!");
        }
    }
}
