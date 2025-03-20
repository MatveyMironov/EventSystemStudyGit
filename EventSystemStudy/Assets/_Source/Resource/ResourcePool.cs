using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourcesSystem
{
    public class ResourcePool
    {
        private readonly Dictionary<Resource, int> _resources = new();

        public event Action<Resource> OnResourceCountChanged;

        public void AddResource(Resource resource, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));

            _resources.TryAdd(resource, 0);

            _resources[resource] += count;
            OnResourceCountChanged?.Invoke(resource);
        }

        public bool TryRemoveResource(Resource resource, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));

            if (_resources.ContainsKey(resource))
            {
                if (_resources[resource] >= count)
                {
                    _resources[resource] -= count;
                    OnResourceCountChanged?.Invoke(resource);

                    return true;
                }

                _resources[resource] = 0;
                OnResourceCountChanged?.Invoke(resource);
            }

            return false;
        }

        public bool TryGetResourceCount(Resource resource, out int count)
        {
            return _resources.TryGetValue(resource, out count);
        }

        public void Reset()
        {
            foreach (Resource resource in _resources.Keys.ToArray())
            {
                _resources[resource] = 0;
                OnResourceCountChanged?.Invoke(resource);
            }
        }
    }
}
