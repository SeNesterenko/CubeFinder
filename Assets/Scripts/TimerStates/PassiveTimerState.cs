using StateMachine;

namespace TimerStates
{
    public class PassiveTimerState : BaseState
    {
        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public void ChangeState()
        {
            StateMachine.ChangeState(((TimerStateMachine) StateMachine).GetTimerToView());
        }
    }
}