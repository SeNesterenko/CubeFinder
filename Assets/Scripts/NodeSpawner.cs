using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    [SerializeField] private GameNode[] _numbersNodes;
    [SerializeField] int _maxNodes;
    [SerializeField] private int _quantityNodesPerStep;
    private RandomizedSet _randomizer;

    private int _currentQuantityNodes;

    private void Awake()
    {
        _randomizer = new RandomizedSet();
        _currentQuantityNodes = _quantityNodesPerStep;
        foreach (var numbersNode in _numbersNodes)
        {
            _randomizer.Insert(numbersNode);
        }
    }

    public GameNode[] GetRandomNodes()
    {
        var nodes = new GameNode[_currentQuantityNodes];
        for (var i = 0; i < nodes.Length; i++)
        {
            nodes[i] = _randomizer.GetRandom();
            _randomizer.Remove(nodes[i]);
        }

        return nodes;
    }
}