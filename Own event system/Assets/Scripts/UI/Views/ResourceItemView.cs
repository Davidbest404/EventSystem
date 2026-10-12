using UnityEngine;
using TMPro;

namespace MyGame.UI.Views
{
    public class ResourceItemView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _nameText;
        [SerializeField] TextMeshProUGUI _amountText;

        public void Setup(string resourceName, int amount)
        {
            _nameText.text = resourceName;
            _amountText.text = amount.ToString();
        }
    }
}
