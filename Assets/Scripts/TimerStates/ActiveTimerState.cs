using System;
using StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace TimerStates
{
    public class ActiveTimerState : BaseState
    {
        [SerializeField] private UnityEvent _onTimeIsUp;
        [SerializeField] private TMP_Text[] _timers;
        [SerializeField] private float _timeToView = 5f;

        private float _currentTime;
        
        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void Enter()
        {
            _currentTime = _timeToView;
        }

        public override void UpdateLogic()
        {
            if (_currentTime <= 0)
            {
                _onTimeIsUp.Invoke();
                StateMachine.ChangeState(((TimerStateMachine)StateMachine).GetPassiveTimerState());
            }
            else
            {
                _currentTime -= Time.deltaTime;
                
                foreach (var text in _timers)
                {
                    text.text = Math.Round(_currentTime, 0).ToString();
                }
            }
        }
    }
}