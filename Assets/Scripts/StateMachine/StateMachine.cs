using UnityEngine;

namespace StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        private BaseState _currentState;
        
        public void ChangeState(BaseState newState)
        {
            ReloadState(newState);
            _currentState.Enter();
        }

        public void ChangeStateWithContext(BaseState newState, IStateContext context)
        {
            ReloadState(newState);
            _currentState.EnterWithContext(context);
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }
        
        private void Start()
        {
            _currentState = GetInitialState();
            _currentState?.Enter();
        }

        private void Update()
        {
            _currentState?.UpdateLogic();
        }

        private void LateUpdate()
        {
            _currentState?.UpdatePhysics();
        }

        private void ReloadState(BaseState newState)
        {
            _currentState.Exit();
            _currentState = newState;
        }
    }
}