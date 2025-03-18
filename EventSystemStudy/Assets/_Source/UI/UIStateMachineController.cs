using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class UIStateMachineController : MonoBehaviour
    {
        [SerializeField] private List<PanelAndButton> panelsAndButtons = new();

        private void Start()
        {
            UIStateMachine uIStateMachine = new();

            foreach (PanelAndButton panelAndButton in panelsAndButtons)
            {
                UIState uIState = new(panelAndButton.Panel);
                panelAndButton.Button.onClick.AddListener(() => uIStateMachine.SetUIState(uIState));
            }
        }

        [Serializable]
        private struct PanelAndButton
        {
            public RectTransform Panel;
            public Button Button;
        }
    }
}
