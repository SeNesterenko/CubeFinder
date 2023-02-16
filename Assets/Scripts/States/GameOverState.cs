using DG.Tweening;
using JetBrains.Annotations;
using StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace States
{
    public class GameOverState : BaseState
    {
        [SerializeField] private Canvas _gameOverScreen;

        [SerializeField] private Button _buttonContinue;
        [SerializeField] private Button _buttonRestart;

        [SerializeField] private ParticleSystem _winEffect;

        private static readonly Vector3 DefaultButtonRestartPosition = new(-100f, -120f, 0);
        private static readonly Vector3 AloneButtonRestartPosition = new(0f, -120f, 0);
        
        private static readonly Vector3 ScaleWonNode = new(0.5f, 0.5f, 1f);
        private static readonly Vector2 RectScaleWonNode = new(600f, 400f);
        private static readonly Vector3 PositionWonNode = new(0f, 80f, 0f);

        private IStateContext _context;
        private GameNode _target;
        private CanvasGroup _canvasGroup;
        
        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
            _canvasGroup = _gameOverScreen.GetComponent<CanvasGroup>();
        }

        public override void EnterWithContext(IStateContext context)
        {
            var rectTransform = _buttonRestart.gameObject.GetComponent<RectTransform>();
            ReloadButtonPositions(rectTransform);
            
            _canvasGroup.DOFade(1f,0.5f).OnComplete(() => _gameOverScreen.gameObject.SetActive(true));
            
            _context = context;
            _target = _context.CurrentTargetNode;
            
            if (context.CurrentQuantityNodes >= context.MaxQuantityNodes)
            {
                _buttonContinue.gameObject.SetActive(false);
                rectTransform.localPosition = AloneButtonRestartPosition;
            }

            _target = InstantiateGameNode(_target);
            _winEffect.Play();
        }

        public override void Exit()
        {
            _canvasGroup.DOFade(0f,0.5f).OnComplete(() =>
            {
                _gameOverScreen.gameObject.SetActive(false);
                Destroy(_target.gameObject);
                _winEffect.Stop();
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

        private void ReloadButtonPositions(RectTransform reloadButtonPosition)
        {
            _buttonContinue.gameObject.SetActive(true);
            reloadButtonPosition.localPosition = DefaultButtonRestartPosition;
        }
        
        private GameNode InstantiateGameNode(GameNode node)
        {
            node = Instantiate(node, _gameOverScreen.transform);
            var animator = node.GetComponent<Animator>();
            var nodeRectTransform = node.gameObject.GetComponent<RectTransform>();

            animator.enabled = false;
            nodeRectTransform.localScale = ScaleWonNode;
            nodeRectTransform.localPosition = PositionWonNode;
            nodeRectTransform.sizeDelta = RectScaleWonNode;

            node.VibrateNode();

            return node;
        }
    }
}