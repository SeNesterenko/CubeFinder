using JetBrains.Annotations;
using StateMachine;
using TMPro;
using UnityEngine;

namespace States
{
    public class GameState : BaseState
    {
        [SerializeField] private GameController _gameController;
        [SerializeField] private Canvas _gameScreen;

        [SerializeField] private TMP_Text _text1;
        [SerializeField] private TMP_Text _text2;
        
        private IStateContext _context;
        
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void EnterWithContext(IStateContext context)
        {
            base.Enter();
            _context = context;

            _text1.text = "Find" + _context.GetCurrentLevelTargetNode().GetName();
            _text2.text = "Find" + _context.GetCurrentLevelTargetNode().GetName();
            
            _gameScreen.gameObject.SetActive(true);
            _gameController.Initialize(_context.GetCurrentLevel(), _context.GetCurrentLevelTargetNode(), ChangeState);
        }

        public override void Exit()
        {
            base.Exit();
            
            _gameController.ResetNodes();
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