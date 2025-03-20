using ResourcesSystem;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UISystem
{
    internal class ResourceCountChangeMenuController
    {
        private readonly ResourceCountChangeMenu _resourceCountChangeMenu;

        private readonly Dictionary<int, Resource> _dropdownResourceOptions = new();

        public ResourceCountChangeMenuController(ResourceCountChangeMenu resourceCountChangeMenu)
        {
            _resourceCountChangeMenu = resourceCountChangeMenu != null ? resourceCountChangeMenu : throw new ArgumentNullException(nameof(resourceCountChangeMenu));

            List<string> dropdownOptions = new();

            foreach (var resource in Enum.GetValues(typeof(Resource)))
            {
                dropdownOptions.Add(resource.ToString());

                if (resource is Resource definetlyAResource)
                {
                    _dropdownResourceOptions.Add(dropdownOptions.Count - 1, definetlyAResource);
                }
            }

            _resourceCountChangeMenu.Dropdown.AddOptions(dropdownOptions);

            _resourceCountChangeMenu.Button.onClick.AddListener(RequestResourseCountChange);
        }

        public event Action<Resource, int> OnResourceCountChangeRequested;

        private void RequestResourseCountChange()
        {
            if (_dropdownResourceOptions.TryGetValue(_resourceCountChangeMenu.Dropdown.value, out Resource resource))
            {
                int count = int.Parse(_resourceCountChangeMenu.InputField.text);

                if (count > 0)
                {
                    OnResourceCountChangeRequested?.Invoke(resource, count);

                    _resourceCountChangeMenu.InputField.text = "";
                }
            }
        }
    }
}
