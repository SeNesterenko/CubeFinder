using TimerStates;
using UnityEngine;

namespace StateMachine
{
    public class TimerStateMachine : StateMachine
    {
        [SerializeField] private TimerToViewState _timerToViewState;
        [SerializeField] private TimerToChooseState _timerToChooseState;
        [SerializeField] private PassiveTimerState _passiveTimerState;
        
        private void Awake()
        {
            _timerToViewState.Initialize(this);
            _timerToChooseState.Initialize(this);
            _passiveTimerState.Initialize(this);
        }

        public TimerToViewState GetTimerToView()
        {
            return _timerToViewState;
        }
        
        public TimerToChooseState GetTimerToChoose()
        {
            return _timerToChooseState;
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