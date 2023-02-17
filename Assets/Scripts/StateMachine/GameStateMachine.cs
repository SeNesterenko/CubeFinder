using System;
using States;
using UnityEngine;

namespace StateMachine
{
    public class GameStateMachine : StateMachine
    {
        [SerializeField] private SelectionLevelState _selectionLevelState;
        [SerializeField] private GameState _gameState;
        [SerializeField] private GameOverState _gameOverState;
        
        private void Awake()
        {
            _selectionLevelState.Initialize(this);
            _gameState.Initialize(this);
            _gameOverState.Initialize(this);
        }

        public SelectionLevelState GetSelectionLevelParametersState()
        {
            return _selectionLevelState;
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
            return _selectionLevelState;
        }
    }
}