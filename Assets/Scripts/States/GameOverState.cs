using JetBrains.Annotations;
using StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace States
{
    public class GameOverState : BaseState
    {
        [SerializeField] private Canvas _gameOverScreen;
        [SerializeField] private Vector3 _scaleWonNode;
        [SerializeField] private Vector2 _rectScaleWonNode;
        [SerializeField] private Vector3 _positionWonNode;

        [SerializeField] private Button _buttonContinue;
        [SerializeField] private Button _buttonRestart;

        [SerializeField] private Vector3 _defaultButtonRestartPosition;
        [SerializeField] private Vector3 _aloneButtonRestartPosition;
        
        private IStateContext _context;
        private GameNode _target;
        private GameNode _nextTarget;

        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void EnterWithContext(IStateContext context)
        {
            base.Enter();

            var rectTransform = _buttonRestart.gameObject.GetComponent<RectTransform>();
            ReloadButtonPositions(rectTransform);
            
            _gameOverScreen.gameObject.SetActive(true);
            
            if (context == null)
            {
                _buttonContinue.gameObject.SetActive(false);
                rectTransform.localPosition = _aloneButtonRestartPosition;
                _nextTarget = InstantiateGameNode(_nextTarget);
                return;
            }
            
            _context = context;
            _nextTarget = _context.GetCurrentLevelTargetNode();
            
            _target = _context.GetPreviousTargetNode();
            _target = InstantiateGameNode(_target);
            
            Debug.Log(_nextTarget.GetName());
        }

        public override void Exit()
        {
            base.Exit();

            if (_target != null)
            {
                Destroy(_target.gameObject);
                _target = null;
            }
            else
            {
                Destroy(_nextTarget);
                _nextTarget = null;
            }
            
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

        private void ReloadButtonPositions(RectTransform reloadButtonPosition)
        {
            _buttonContinue.gameObject.SetActive(true);
            reloadButtonPosition.localPosition = _defaultButtonRestartPosition;
        }
        
        private GameNode InstantiateGameNode(GameNode node)
        {
            node = Instantiate(node, _gameOverScreen.transform);
            var nodeRectTransform = node.gameObject.GetComponent<RectTransform>();
            
            nodeRectTransform.localScale = _scaleWonNode;
            nodeRectTransform.localPosition = _positionWonNode;
            nodeRectTransform.sizeDelta = _rectScaleWonNode;

            return node;
        }
    }
}