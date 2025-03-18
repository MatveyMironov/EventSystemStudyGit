using System;

namespace UISystem
{
    public class ResourceItemController
    {
        private readonly ResourceItem _resourceItem;

        public ResourceItemController(ResourceItem resourceItem)
        {
            _resourceItem = resourceItem != null ? resourceItem : throw new ArgumentNullException(nameof(resourceItem));
        }

        public void DisplayResourceName(string resourceName)
        {
            _resourceItem.ResourceNameText.text = resourceName;
        }

        public void DisplayResourceCount(int resourceCount)
        {
            _resourceItem.ResourceCountText.text = resourceCount.ToString();
        }
    }
}
