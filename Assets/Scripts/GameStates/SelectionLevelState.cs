using DG.Tweening;
using JetBrains.Annotations;
using StateMachine;
using UnityEngine;

namespace GameStates
{
    public class SelectionLevelState : BaseState
    {
        [SerializeField] private Canvas _selectionLevelScreen;
        [SerializeField] private GameMap _defaultGameMap;
        [SerializeField] private CanvasGroup _canvasGroup;

        // ReSharper disable once RedundantOverriddenMember
        public override void Initialize(StateMachine.StateMachine stateMachine)
        {
            base.Initialize(stateMachine);
        }

        public override void Enter()
        {
            _selectionLevelScreen.gameObject.SetActive(true);
            _canvasGroup.DOFade(1f,0.5f);
        }

        public override void Exit()
        {
            _canvasGroup.DOFade(0f,0.5f).OnComplete(() => _selectionLevelScreen.gameObject.SetActive(false));
        }

        //Call it when selecting the level parameters
        [UsedImplicitly]
        public void ChangeState(int typeParams)
        {
            _defaultGameMap.TypeParams = typeParams;
            StateMachine.ChangeStateWithContext(((GameStateMachine) StateMachine).GetGameState(), _defaultGameMap);
        }
    }
}