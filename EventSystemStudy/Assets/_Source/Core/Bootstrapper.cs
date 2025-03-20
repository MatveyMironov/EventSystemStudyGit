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
        [SerializeField] private ResourceCountChangeMenu addMenu;
        [SerializeField] private ResourceCountChangeMenu removeMenu;

        private void Start()
        {
            UISwitcher uISwitcher = new();

            foreach (PanelAndButton panelAndButton in panelsAndButtons)
            {
                UIState uIState = new(panelAndButton.Panel);
                panelAndButton.Button.onClick.AddListener(() => uISwitcher.SwitchUI(uIState));
            }

            ResourcePool resourcePool = new();

            MainMenuController mainMenuController = new(mainMenu);
            mainMenuController.DisplayResources();

            ResourcePoolMainMenuConnector resourcePoolMainMenuConnector = new(mainMenuController);
            resourcePoolMainMenuConnector.ConnectResourcePool(resourcePool);

            ResourceCountChangeMenuController addMenuController = new(addMenu);
            addMenuController.OnResourceCountChangeRequested += resourcePool.AddResource;

            ResourceCountChangeMenuController removeMenuController = new(removeMenu);
            removeMenuController.OnResourceCountChangeRequested += (Resource resource, int count) => resourcePool.TryRemoveResource(resource, count);
        }

        [Serializable]
        private struct PanelAndButton
        {
            public RectTransform Panel;
            public Button Button;
        }
    }
}
