using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private Canvas _gameScreen;
    
    private GameMap _gameMap;
    private GameNode _targetNode;

    public void Initialize(GameMap gameMap, GameNode target, UnityAction changeState)
    {
        _gameMap = Instantiate(gameMap, _gameScreen.transform);
        _targetNode = target;
        
        foreach (var gameNode in _gameMap.GetGameNodes())
        {
            if (gameNode.GetName() == target.GetName())
            {
                gameNode.GetButton().onClick.AddListener(SelectTargetNode);
                gameNode.GetButton().onClick.AddListener(changeState);
            }
            else
            {
                gameNode.GetButton().onClick.AddListener(SelectWrongNode);
            }
        }
    }
    
    //Call it when a user makes the right choice
    [UsedImplicitly]
    public void SelectTargetNode()
    {
        Debug.Log("Target");
    }
    
    //Call it when a user makes the wrong choice
    [UsedImplicitly]
    public void SelectWrongNode()
    {
        Debug.Log("Fail");
    }

    public void ResetNodes()
    {
        Destroy(_gameMap.gameObject);
    }
}