using JetBrains.Annotations;
using StateMachine;
using UnityEngine;

namespace States
{
    public class GameOverState : BaseState
    {
        [SerializeField] private Canvas _gameOverScreen;
        [SerializeField] private Vector3 _scaleWonNode;
        [SerializeField] private Vector2 _rectScaleWonNode;
        [SerializeField] private Vector3 _positionWonNode;
        
        private IStateContext _context;

        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void EnterWithContext(IStateContext context)
        {
            base.Enter();
            _gameOverScreen.gameObject.SetActive(true);
            _context = context;

            var target = Instantiate(_context.GetPreviousTargetNode(), _gameOverScreen.transform);
            var targetRectTransform = target.gameObject.GetComponent<RectTransform>();
            ConfigureTargetNode(targetRectTransform);
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

        private void ConfigureTargetNode(RectTransform nodeRectTransform)
        {
            nodeRectTransform.localScale = _scaleWonNode;
            nodeRectTransform.localPosition = _positionWonNode;
            nodeRectTransform.sizeDelta = _rectScaleWonNode;
        }
    }
}