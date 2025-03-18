using System;
using UnityEngine;

namespace UISystem
{
    public class UIState
    {
        private readonly RectTransform _panel;

        public UIState(RectTransform panel)
        {
            _panel = panel != null ? panel : throw new ArgumentNullException(nameof(panel));
        }

        public void EnterState()
        {
            _panel.gameObject.SetActive(true);
        }

        public void ExitState()
        {
            _panel.gameObject.SetActive(false);
        }
    }
}
