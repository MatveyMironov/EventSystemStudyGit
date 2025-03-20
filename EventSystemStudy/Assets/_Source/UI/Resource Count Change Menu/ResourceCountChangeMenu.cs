using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    internal class ResourceCountChangeMenu : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private Button button;

        public TMP_InputField InputField { get { return inputField; } }
        public TMP_Dropdown Dropdown { get { return dropdown; } }
        public Button Button { get { return button; } }
    }
}
