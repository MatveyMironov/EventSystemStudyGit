namespace UISystem
{
    public class UISwitcher
    {
        private UIState _activeState;

        public void SwitchUI(UIState newState)
        {
            if (newState == null || newState == _activeState)
                return;

            _activeState?.ExitState();
            _activeState = newState;
            _activeState.EnterState();
        }
    }
}