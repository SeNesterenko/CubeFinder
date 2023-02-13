using JetBrains.Annotations;
using StateMachine;
using UnityEngine;

namespace States
{
    public class GameState : BaseState
    {
        [SerializeField] private GameController _gameController;

        private Canvas _gameScreen;
        private IStateContext _context;
        
        public override void Initialize(StateMachine.StateMachine stateMachine, string name = "GameState")
        {
            base.Initialize(stateMachine, name);
        }

        public override void EnterWithContext(IStateContext context)
        {
            base.Enter();
            
            _context = context;
            _gameScreen = _context.GetCurrentGameScreen();

            _gameScreen.gameObject.SetActive(true);
            _gameController.Initialize(_context.GetCurrentLevelGameNodes(), _context.GetCurrentLevelTargetNode());
        }

        public override void Exit()
        {
            base.Exit();
            _gameScreen.gameObject.SetActive(false);
        }

        //Call it when user win
        [UsedImplicitly]
        public void ChangeState()
        {
            StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameOverState(), _context.GetNextLevel());
        }
    }
}