using System;
using StateMachine;
using UnityEngine;

public class GameMap : MonoBehaviour, IStateContext
{
    [SerializeField] private GameNode[] _gameNodesPrefabs;
    [SerializeField] private GameNode _currentTargetNode;
    [SerializeField] private GameNode _previousTargetNode;
    [SerializeField] private GameMap _nextLevel;

    public GameNode[] GetCurrentLevelGameNodes()
    {
        return _gameNodesPrefabs;
    }

    public GameNode GetCurrentLevelTargetNode()
    {
        return _currentTargetNode;
    }

    public GameNode GetPreviousTargetNode()
    {
        return _previousTargetNode != null ? _previousTargetNode : null;
    }

    public GameMap GetNextLevel()
    {
        return _nextLevel;
    }
}