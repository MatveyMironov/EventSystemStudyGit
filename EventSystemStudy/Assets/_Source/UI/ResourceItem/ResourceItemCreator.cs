using System;
using UnityEngine;

namespace UISystem
{
    [Serializable]
    public class ResourceItemCreator
    {
        [SerializeField] private ResourceItem resourceItemPrefab;
        [SerializeField] private RectTransform resourceItemsRoot;
        public ResourceItemController CreateResourceItem()
        {
            ResourceItem resourceItemInstance = GameObject.Instantiate(resourceItemPrefab, resourceItemsRoot);

            return new(resourceItemInstance);
        }
    }
}
