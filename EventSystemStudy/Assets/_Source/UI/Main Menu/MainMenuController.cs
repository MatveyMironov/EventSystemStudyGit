using ResourcesSystem;
using System;
using System.Collections.Generic;

namespace UISystem
{
    public class MainMenuController
    {
        private readonly MainMenu _mainMenu;

        private readonly Dictionary<Resources, ResourceItemController> resourceItemControllers = new();

        private ResourcesStorage _storage;

        public MainMenuController(MainMenu mainMenu)
        {
            _mainMenu = mainMenu != null ? mainMenu : throw new ArgumentNullException(nameof(mainMenu));
        }

        public void DisplayResources(ResourcesStorage storage)
        {
            var resources = Enum.GetValues(typeof(Resources));

            foreach (var resource in resources)
            {
                ResourceItemController resourceItemController = _mainMenu.ResourceItemCreator.CreateResourceItem();
                resourceItemController.DisplayResourceName(resource.ToString());
                resourceItemController.DisplayResourceCount(0);
                resourceItemControllers.Add(resource, resourceItemController);
            }

            storage.OnResourceCountChanged += DisplayResourceCount;
        }

        private void DisplayResourceCount(Resources resource)
        {
            if (_storage == null)
                return;

            if (_storage.TryGetResource(resource, out int count))
            {
                if (resourceItemControllers.TryGetValue(resource, out ResourceItemController resourceItemController))
                {
                    resourceItemController.DisplayResourceCount(count);
                }
            }
        }
    }
}
