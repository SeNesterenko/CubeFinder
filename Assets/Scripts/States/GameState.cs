using DG.Tweening;
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
        private CanvasGroup _canvasGroup;
        
        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
            _canvasGroup = _gameScreen.GetComponent<CanvasGroup>();
        }

        public override void EnterWithContext(IStateContext context)
        {
            _canvasGroup.DOFade(1f,0.5f).OnComplete(() => _gameScreen.gameObject.SetActive(true));
            _context = _gameController.Initialize(context.TypeParams, ChangeState);
            
            _text1.text = "Find" + _context.CurrentTargetNode.GetName();
            _text2.text = "Find" + _context.CurrentTargetNode.GetName();
        }

        public override void Exit()
        {
            _canvasGroup.DOFade(0f,0.5f).OnComplete(() =>
            {
                _gameScreen.gameObject.SetActive(false);
                _gameController.ResetNodes();
            });
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