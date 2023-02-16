using JetBrains.Annotations;
using StateMachine;
using UnityEngine;

namespace States
{
    public class SelectionLevelParametersState : BaseState
    {
        [SerializeField] private Canvas _currentScreen;
        [SerializeField] private GameMap _defaultGameMap;

        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void Enter()
        {
            _currentScreen.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            _currentScreen.gameObject.SetActive(false);
        }

        //Call it when selecting the level parameters
        [UsedImplicitly]
        public void ChangeState(int typeParams)
        {
            _defaultGameMap.TypeParams = typeParams;
            StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _defaultGameMap);
        }
    }
}