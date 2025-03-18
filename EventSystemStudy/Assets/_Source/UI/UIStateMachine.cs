namespace UISystem
{
    public class UIStateMachine
    {
        private UIState _activeState;

        public void SetUIState(UIState newState)
        {
            if (newState == null || newState == _activeState)
                return;

            _activeState?.ExitState();
            _activeState = newState;
            _activeState.EnterState();
        }
    }
}