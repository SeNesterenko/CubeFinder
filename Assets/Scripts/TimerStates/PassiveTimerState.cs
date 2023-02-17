using StateMachine;
using UnityEngine;

namespace TimerStates
{
    public class PassiveTimerState : BaseState
    {
        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }
        
        public override void Enter()
        {
            Debug.Log("Enter to PassiveTimerState");
        }

        public override void Exit()
        {
            Debug.Log("Exit from PassiveTimerState");
        }

        public void ChangeState()
        {
            StateMachine.ChangeState(((TimerStateMachine) StateMachine).GetTimerToView());
        }
    }
}