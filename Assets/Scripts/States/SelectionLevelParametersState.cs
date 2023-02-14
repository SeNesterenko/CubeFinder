using JetBrains.Annotations;
using StateMachine;
using UnityEngine;

namespace States
{
    public class SelectionLevelParametersState : BaseState
    {
        private enum LevelParams
        {
            Cars = 0,
            Letters = 1,
            Animals = 2
        }
        
        [SerializeField] private Canvas _currentScreen;
        
        [SerializeField] private GameMap _carsGameMapFirstLevelPrefab;
        [SerializeField] private GameMap _lettersGameMapFirstLevelPrefab;
        [SerializeField] private GameMap _animalsGameMapFirstLevelPrefab;
        
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
            switch (typeParams)
            {
                case  (int)LevelParams.Cars:
                    StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _carsGameMapFirstLevelPrefab);
                    break;
                case  (int)LevelParams.Letters:
                    StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _lettersGameMapFirstLevelPrefab);
                    break;
                case  (int)LevelParams.Animals:
                    StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _animalsGameMapFirstLevelPrefab);
                    break;
            }
        }
    }
}