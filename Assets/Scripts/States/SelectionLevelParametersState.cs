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
        
        [SerializeField] private Canvas _gameMapsScreen;
        
        [SerializeField] private GameMap _carsGameMapPrefab;
        [SerializeField] private GameMap _lettersGameMapPrefab;
        [SerializeField] private GameMap _animalsGameMapPrefab;
        
        public override void Initialize(StateMachine.StateMachine stateMachine, string name = "SelectionLevelParametersState")
        {
            base.Initialize(stateMachine, name);
        }

        public override void Enter()
        {
            base.Enter();
            _gameMapsScreen.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();
            _gameMapsScreen.gameObject.SetActive(false);
        }

        //Call it when selecting the level parameters
        [UsedImplicitly]
        public void ChangeState(int typeParams)
        {
            switch (typeParams)
            {
                case  (int)LevelParams.Cars:
                    StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _carsGameMapPrefab);
                    break;
                case  (int)LevelParams.Letters:
                    StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _lettersGameMapPrefab);
                    break;
                case  (int)LevelParams.Animals:
                    StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _animalsGameMapPrefab);
                    break;
            }
        }
    }
}