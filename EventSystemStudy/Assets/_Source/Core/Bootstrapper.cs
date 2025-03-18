using ResourcesSystem;
using System;
using System.Collections.Generic;
using UISystem;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<PanelAndButton> panelsAndButtons = new();
        [SerializeField] private MainMenu mainMenu;

        private void Start()
        {
            UISwitcher uISwitcher = new();

            foreach (PanelAndButton panelAndButton in panelsAndButtons)
            {
                UIState uIState = new(panelAndButton.Panel);
                panelAndButton.Button.onClick.AddListener(() => uISwitcher.SwitchUI(uIState));
            }

            ResourcesStorage storage = new();

            MainMenuController mainMenuController = new(mainMenu);
            mainMenuController.DisplayResources();
        }

        [Serializable]
        private struct PanelAndButton
        {
            public RectTransform Panel;
            public Button Button;
        }
    }
}
