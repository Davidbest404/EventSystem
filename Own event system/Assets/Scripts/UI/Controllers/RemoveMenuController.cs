using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using MyGame.Core.Types;
using MyGame.Core.Signals;
using deVoid.Utils;

namespace MyGame.UI.Controllers
{
    public class RemoveMenuController : MonoBehaviour
    {
        [SerializeField] TMP_Dropdown _resourceDropdown;
        [SerializeField] TMP_InputField _amountInputField;
        [SerializeField] Button _actionButton;

        void Start()
        {
            AutoFillDropdown();
            _actionButton.onClick.AddListener(OnActionButtonClicked);
        }

        void AutoFillDropdown()
        {
            _resourceDropdown.ClearOptions();
            List<string> options = new List<string>(System.Enum.GetNames(typeof(ResourceType)));
            _resourceDropdown.AddOptions(options);
        }

        void OnActionButtonClicked()
        {
            if (int.TryParse(_amountInputField.text, out int amount))
            {
                ResourceType selectedResource = (ResourceType)_resourceDropdown.value;
                deVoid.Utils.Signals.Get<ResourceModifierSignal>().Dispatch(selectedResource, amount, false);
                _resourceDropdown.value = 0;
                _amountInputField.text = "";
            }
            else  Debug.LogWarning("Введите корректное число!");
        }
    }
}
