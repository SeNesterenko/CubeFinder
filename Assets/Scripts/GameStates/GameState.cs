using Controllers;
using DG.Tweening;
using JetBrains.Annotations;
using StateMachine;
using TMPro;
using UnityEngine;

namespace GameStates
{
    public class GameState : BaseState
    {
        [SerializeField] private GameController _gameController;
        [SerializeField] private Canvas _gameScreen;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text[] _targetText;

        private IStateContext _context;

        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void EnterWithContext(IStateContext context)
        {
            _gameScreen.gameObject.SetActive(true);
            _canvasGroup.DOFade(1f,0.5f);
            _context = _gameController.Initialize(context.TypeParams, ChangeState);
            
            foreach (var text in _targetText)
            {
                text.text = "Find" + _context.CurrentTargetNode.GetName();
            }
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