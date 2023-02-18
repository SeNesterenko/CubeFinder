using JetBrains.Annotations;
using TimerStates;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ActiveTimerState _activeTimerState;
        [SerializeField] private Canvas _gameScreen;
        [SerializeField] private GameMapCreater _gameMapCreater;
    
        private GameMap _gameMap;

        public GameMap Initialize(int typeParams, UnityAction changeState)
        {
            _gameMap = _gameMapCreater.InstantiateLevel(typeParams, _gameScreen.transform);
        
            foreach (var gameNode in _gameMap.GameNodes)
            {
                if (gameNode.GetName() == _gameMap.CurrentTargetNode.GetName())
                {
                    gameNode.GetButton().onClick.AddListener(changeState);
                    gameNode.GetButton().onClick.AddListener(_activeTimerState.ChangeState);
                }
            }

            return _gameMap;
        }

        //Call it when timerToView is over
        [UsedImplicitly]
        public void ChangeStateOfNodes()
        {
            foreach (var gameNode in _gameMap.GameNodes)
            {
                gameNode.DeleteContent();
            }
        }

        public void ResetNodes()
        {
            Destroy(_gameMap.gameObject);
        }
    }
}