using System;
using StateMachine;
using TMPro;
using UnityEngine;

namespace TimerStates
{
    public class TimerToChooseState : BaseState
    {
        [SerializeField] private TMP_Text _leftUpTimer;
        [SerializeField] private TMP_Text _rightUpTimer;
        [SerializeField] private TMP_Text _leftDownTimer;
        [SerializeField] private TMP_Text _rightDownTimer;
        
        [SerializeField] private float _timeToChoose = 5f;
        
        private float _currentTime;
        
        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }
        
        public override void Enter()
        {
            _currentTime = _timeToChoose;
            Debug.Log("Enter to TimerToChoose");
        }

        public override void UpdateLogic()
        {
            if (_currentTime <= 0)
            {
                SwitchToLoseMode();
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
            Debug.Log("Exit from TimerToChoose");
        }

        public void SwitchToWinMode()
        {
            Debug.Log("Win");
        }

        private void SwitchToLoseMode()
        {
            Debug.Log("Lose");
            StateMachine.ChangeState(((TimerStateMachine) StateMachine).GetPassiveTimerState());
        }
    }
}