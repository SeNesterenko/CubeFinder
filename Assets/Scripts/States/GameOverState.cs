using System.Collections.Generic;
using JetBrains.Annotations;
using StateMachine;
using UnityEngine;

namespace States
{
    public class GameOverState : BaseState
    {
        [SerializeField] private Canvas _gameOverScreen;

        private IStateContext _context;
        private List<GameNode> _previousResults;

        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void EnterWithContext(IStateContext context)
        {
            base.Enter();
            _gameOverScreen.gameObject.SetActive(true);
            _context = context;
        }
        
        public override void Exit()
        {
            base.Exit();
            _gameOverScreen.gameObject.SetActive(false);
        }
        
        //Call it when a user chooses to restart the game
        [UsedImplicitly]
        public void RestartGame()
        {
            StateMachine.ChangeState(((GameStateMachine) StateMachine).GetSelectionLevelParametersState());
        }
        
        //Call it when a user chooses to continue the game
        [UsedImplicitly]
        public void ContinueGame()
        {
            StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _context);
        }
    }
}