using UnityEngine;

namespace StateMachine
{
    public class BaseState : MonoBehaviour
    {
        [HideInInspector] public string Name;
        protected StateMachine StateMachine;

        //TODO: Maybe remove name?
        public virtual void Initialize(StateMachine stateMachine, string name)
        {
            Name = name;
            StateMachine = stateMachine;
        }
        
        public virtual void Enter() { }
        public virtual void EnterWithContext(IStateContext context) { }
        public virtual void UpdateLogic() { }
        public virtual void UpdatePhysics() { }
        public virtual void Exit() { }
    }
}