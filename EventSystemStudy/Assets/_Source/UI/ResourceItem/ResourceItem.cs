using TMPro;
using UnityEngine;

namespace UISystem
{
    [RequireComponent(typeof(RectTransform))]
    public class ResourceItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resourceNameText;
        [SerializeField] private TextMeshProUGUI resourceCountText;

        public TextMeshProUGUI ResourceNameText { get { return resourceNameText; } }
        public TextMeshProUGUI ResourceCountText { get { return resourceCountText; } }
    }
}