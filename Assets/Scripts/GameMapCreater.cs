using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameMapCreater : MonoBehaviour
{
    [SerializeField] private GameMap _gameMapPrefab;
    
    [SerializeField] private GameNode[] _lettersNodes;
    [SerializeField] private GameNode[] _animalsNodes;
    [SerializeField] private GameNode[] _numbersNodes;
    
    [SerializeField] private int _maxQuantityNodes;
    [SerializeField] private int _quantityNodesPerStep;
    
    private RandomizedSet _lettersRandomizer;
    private RandomizedSet _animalsRandomizer;
    private RandomizedSet _numbersRandomizer;
    
    private int _currentQuantityNodes;

    private void Awake()
    {
        ResetRandomizer();
    }

    public GameMap InstantiateLevel(int typeParams, Transform parent)
    {
        if (_currentQuantityNodes > _maxQuantityNodes)
        {
           ResetRandomizer();
        }

        var currentNodes = new GameNode [_currentQuantityNodes];
        var nodesPrefabs = GetRandomNodes(typeParams);
        var gameMap = Instantiate(_gameMapPrefab, parent);
        
        for (var i = 0; i < nodesPrefabs.Length; i++)
        {
            nodesPrefabs[i].SetBackGroundColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            currentNodes[i] = Instantiate(nodesPrefabs[i], gameMap.transform);
        }

        var indexRandomNode = Random.Range(0, currentNodes.Length);
        
        gameMap.GameNodes = currentNodes;
        gameMap.CurrentTargetNode = nodesPrefabs[indexRandomNode];
        gameMap.MaxQuantityNodes = _maxQuantityNodes;
        gameMap.CurrentQuantityNodes = nodesPrefabs.Length;
        gameMap.TypeParams = typeParams;

        return gameMap;
    }

    //It also called in the unity editor when the level is reloaded
    [UsedImplicitly]
    public void ResetRandomizer()
    {
        _lettersRandomizer = FillRandomizer(_lettersNodes);
        _animalsRandomizer = FillRandomizer(_animalsNodes);
        _numbersRandomizer = FillRandomizer(_numbersNodes);
        
        _currentQuantityNodes = _quantityNodesPerStep;
    }
    
    private GameNode[] GetRandomNodes(int typeParams)
    {
        var nodes = typeParams switch
        {
            (int) LevelParams.Numbers => CollectUniqueNodes(_numbersRandomizer),
            (int) LevelParams.Letters => CollectUniqueNodes(_lettersRandomizer),
            (int) LevelParams.Animals => CollectUniqueNodes(_animalsRandomizer),
            _ => new GameNode[_currentQuantityNodes]
        };

        _currentQuantityNodes += _quantityNodesPerStep;
        
        return nodes;
    }

    private GameNode[] CollectUniqueNodes(RandomizedSet randomizer)
    {
        var uniqueNodes = new GameNode[_currentQuantityNodes];
        for (var i = 0; i < uniqueNodes.Length; i++)
        {
            uniqueNodes[i] = randomizer.GetRandom();
            randomizer.Remove(uniqueNodes[i]);
        }

        return uniqueNodes;
    }

    private static RandomizedSet FillRandomizer(IEnumerable<GameNode> nodes)
    {
        var randomizer = new RandomizedSet();
        
        foreach (var node in nodes)
        {
            randomizer.Insert(node);
        }

        return randomizer;
    }
}