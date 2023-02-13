using States;
using UnityEngine;

namespace StateMachine
{
    public class GameStateMachine : StateMachine
    {
        [SerializeField] private SelectionLevelParametersState _selectionLevelParametersState;
        [SerializeField] private GameState _gameState;
        [SerializeField] private GameOverState _gameOverState;
        
        private void Awake()
        {
            _selectionLevelParametersState.Initialize(this);
            _gameState.Initialize(this);
            _gameOverState.Initialize(this);
        }

        public SelectionLevelParametersState GetSelectionLevelParametersState()
        {
            return _selectionLevelParametersState;
        }

        public GameState GetGameState()
        {
            return _gameState;
        }

        public GameOverState GetGameOverState()
        {
            return _gameOverState;
        }

        protected override BaseState GetInitialState()
        {
            return _selectionLevelParametersState;
        }
    }
}