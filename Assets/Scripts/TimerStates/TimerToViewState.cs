using System;
using StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace TimerStates
{
    public class TimerToViewState : BaseState
    {
        [SerializeField] private UnityEvent _onTimeIsUp;
        
        [SerializeField] private TMP_Text _leftUpTimer;
        [SerializeField] private TMP_Text _rightUpTimer;
        [SerializeField] private TMP_Text _leftDownTimer;
        [SerializeField] private TMP_Text _rightDownTimer;
        
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
            Debug.Log("Enter to TimerToView");
        }

        public override void UpdateLogic()
        {
            if (_currentTime <= 0)
            {
                _onTimeIsUp.Invoke();
                StateMachine.ChangeState(((TimerStateMachine)StateMachine).GetTimerToChoose());
            }
            else
            {
                _currentTime -= Time.deltaTime;
                
                _leftUpTimer.text = Math.Round(_currentTime, 2).ToString();
                _rightUpTimer.text = Math.Round(_currentTime, 2).ToString();
                _leftDownTimer.text = Math.Round(_currentTime, 2).ToString();
                _rightDownTimer.text = Math.Round(_currentTime, 2).ToString();
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit from TimerToView");
        }
    }
}