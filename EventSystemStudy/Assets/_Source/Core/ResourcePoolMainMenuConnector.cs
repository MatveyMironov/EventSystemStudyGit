using ResourcesSystem;
using System;
using UISystem;

namespace Core
{
    internal class ResourcePoolMainMenuConnector
    {
        private readonly MainMenuController _mainMenuController;

        private ResourcePool _resourcePool;

        public ResourcePoolMainMenuConnector(MainMenuController mainMenuController)
        {
            _mainMenuController = mainMenuController ?? throw new ArgumentNullException(nameof(mainMenuController));
        }

        public void ConnectResourcePool(ResourcePool resourcePool)
        {
            _resourcePool = resourcePool ?? throw new ArgumentNullException(nameof(resourcePool));

            _resourcePool.OnResourceCountChanged += DisplayResourceCount;
        }

        public void DisconnectResourcePool()
        {
            if (_resourcePool == null)
                return;

            _resourcePool.OnResourceCountChanged -= DisplayResourceCount;

            _resourcePool = null;
        }

        private void DisplayResourceCount(Resource resource)
        {
            if (_resourcePool == null)
                return;

            if (_resourcePool.TryGetResourceCount(resource, out int count))
            {
                _mainMenuController.DisplayResourceCount(resource, count);
            }
        }
    }
}
