using ResourcesSystem;
using System;
using System.Collections.Generic;

namespace UISystem
{
    public class MainMenuController
    {
        private readonly MainMenu _mainMenu;

        private readonly Dictionary<Resource, ResourceItemController> _resourceItemControllers = new();

        public MainMenuController(MainMenu mainMenu)
        {
            _mainMenu = mainMenu != null ? mainMenu : throw new ArgumentNullException(nameof(mainMenu));
        }

        public void DisplayResources()
        {
            foreach (var resource in Enum.GetValues(typeof(Resource)))
            {
                ResourceItemController resourceItemController = _mainMenu.ResourceItemCreator.CreateResourceItem();
                resourceItemController.DisplayResourceName(resource.ToString());
                resourceItemController.DisplayResourceCount(0);

                if (resource is Resource definetlyAResource)
                {
                    _resourceItemControllers.TryAdd(definetlyAResource, resourceItemController);
                }
            }
        }

        public void DisplayResourceCount(Resource resource, int count)
        {
            if (_resourceItemControllers.TryGetValue(resource, out ResourceItemController resourceItemController))
            {
                resourceItemController.DisplayResourceCount(count);
            }
        }
    }
}
