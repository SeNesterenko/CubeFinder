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

        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void EnterWithContext(IStateContext context)
        {
            _gameScreen.gameObject.SetActive(true);
            _context = _gameController.Initialize(_context.TypeParams, ChangeState);
            
            _text1.text = "Find" + _context.CurrentTargetNode.GetName();
            _text2.text = "Find" + _context.CurrentTargetNode.GetName();
        }

        public override void Exit()
        {
            _gameController.ResetNodes();
            _gameScreen.gameObject.SetActive(false);
        }

        //Call it when user win
        [UsedImplicitly]
        public void ChangeState()
        {
            StateMachine.ChangeStateWithContext(((GameStateMachine)StateMachine).GetGameOverState(),
                _context);
        }
    }
}