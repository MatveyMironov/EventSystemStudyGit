using System;
using System.Collections.Generic;

namespace ResourcesSystem
{
    public class ResourcesStorage
    {
        private readonly Dictionary<Resources, int> _storedResources = new();

        public event Action<Resources> OnResourceCountChanged;

        public void AddResource(Resources resource, int count)
        {
            if (count < 0) throw new System.ArgumentOutOfRangeException(nameof(count));

            _storedResources.TryAdd(resource, 0);

            _storedResources[resource] += count;
            OnResourceCountChanged?.Invoke(resource);
        }

        public bool TryRemoveResource(Resources resource, int count)
        {
            if (_storedResources.ContainsKey(resource))
            {
                if (_storedResources[resource] >= count)
                {
                    _storedResources[resource] -= count;
                    OnResourceCountChanged?.Invoke(resource);

                    return true;
                }

                _storedResources[resource] = 0;
                OnResourceCountChanged?.Invoke(resource);
            }

            return false;
        }

        public bool TryGetResource(Resources resource, out int count)
        {
            return _storedResources.TryGetValue(resource, out count);
        }
    }
}
