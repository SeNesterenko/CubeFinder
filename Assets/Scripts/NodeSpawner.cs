using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    [SerializeField] private GameMap _gameMapPrefab;
    
    [SerializeField] private GameNode[] _lettersNodes;
    [SerializeField] private GameNode[] _animalsNodes;
    [SerializeField] private GameNode[] _numbersNodes;
    
    [SerializeField] private int _maxNodes;
    [SerializeField] private int _quantityNodesPerStep;
    
    private RandomizedSet _lettersRandomizer;
    private RandomizedSet _animalsRandomizer;
    private RandomizedSet _numbersRandomizer;
    
    private int _currentQuantityNodes;

    private void Awake()
    {
        _currentQuantityNodes = _quantityNodesPerStep;
        ResetRandomizer();
    }

    public GameMap InstantiateLevel(int typeParams, Transform parent)
    {
        if (_currentQuantityNodes > _maxNodes)
        {
           ResetRandomizer(); 
        }

        var nodesPrefabs = GetRandomNodes(typeParams);
        var currentNodes = new GameNode [_currentQuantityNodes];
        Instantiate(_gameMapPrefab, parent);
        
        for (var i = 0; i < nodesPrefabs.Length; i++)
        {
            currentNodes[i] = Instantiate(nodesPrefabs[i], _gameMapPrefab.transform);
        }

        var indexRandomNode = Random.Range(0, currentNodes.Length);
        
        _gameMapPrefab.GameNodes = currentNodes;
        _gameMapPrefab.CurrentTargetNode = currentNodes[indexRandomNode];

        return _gameMapPrefab;
    }

    private void ResetRandomizer()
    {
        _lettersRandomizer = FillRandomizer(_lettersNodes);
        _animalsRandomizer = FillRandomizer(_animalsNodes);
        _numbersRandomizer = FillRandomizer(_numbersNodes);
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