using Controllers;
using DG.Tweening;
using JetBrains.Annotations;
using StateMachine;
using UnityEngine;

namespace GameStates
{
    public class GameOverState : BaseState
    {
        [SerializeField] private Canvas _gameOverScreen;
        [SerializeField] private GameOverController _gameOverController;
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private IStateContext _context;
        private GameNode _target;

        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void EnterWithContext(IStateContext context)
        {
            _gameOverScreen.gameObject.SetActive(true);
            _canvasGroup.DOFade(1f,0.5f);
            
            _context = context;
            _target = _gameOverController.Initialize(_context, _gameOverScreen.transform);
        }

        public override void Exit()
        {
            _canvasGroup.DOFade(0f,0.5f).OnComplete(() =>
            {
                _gameOverScreen.gameObject.SetActive(false);
                Destroy(_target.gameObject);
                _gameOverController.StopGameOverController();
            });
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