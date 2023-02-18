using TimerStates;
using UnityEngine;

namespace StateMachine
{
    public class TimerStateMachine : StateMachine
    {
        [SerializeField] private ActiveTimerState _activeTimerState;
        [SerializeField] private PassiveTimerState _passiveTimerState;
        
        private void Awake()
        {
            _activeTimerState.Initialize(this);
            _passiveTimerState.Initialize(this);
        }

        public ActiveTimerState GetTimerToView()
        {
            return _activeTimerState;
        }

        public PassiveTimerState GetPassiveTimerState()
        {
            return _passiveTimerState;
        }
        
        protected override BaseState GetInitialState()
        {
            return _passiveTimerState;
        }
    }
}