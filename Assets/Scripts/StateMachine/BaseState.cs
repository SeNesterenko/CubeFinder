using UnityEngine;

namespace StateMachine
{
    public class BaseState : MonoBehaviour
    {
        protected StateMachine StateMachine;
        
        public virtual void Initialize(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        
        public virtual void Enter() { }
        public virtual void EnterWithContext(IStateContext context) { }
        public virtual void UpdateLogic() { }
        public virtual void UpdatePhysics() { }
        public virtual void Exit() { }
    }
}