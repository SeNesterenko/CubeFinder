using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private Canvas _gameScreen;
    [SerializeField] private NodeSpawner _nodeSpawner;
    
    private GameMap _gameMap;

    public GameMap Initialize(int typeParams, UnityAction changeState)
    {
        _gameMap = _nodeSpawner.InstantiateLevel(typeParams, _gameScreen.transform);
        
        foreach (var gameNode in _gameMap.GameNodes)
        {
            if (gameNode.GetName() == _gameMap.CurrentTargetNode.GetName())
            {
                gameNode.GetButton().onClick.AddListener(changeState);
            }
        }

        return _gameMap;
    }

    public void ResetNodes()
    {
        Destroy(_gameMap.gameObject);
    }
}