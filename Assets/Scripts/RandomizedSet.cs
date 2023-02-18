using System.Collections.Generic;
using UnityEngine;

public class RandomizedSet 
{
    private Dictionary<GameNode,int> _dictionaryValueIndex = new ();
    private List<GameNode> _values = new ();

    public void Insert(GameNode val) 
    {
        if (_dictionaryValueIndex.ContainsKey(val))
        {
            return;
        }

        _values.Add(val);
        var index = _values.Count - 1;
        _dictionaryValueIndex[val] = index;
    }
    
    public void Remove(GameNode val) 
    {
        if (!_dictionaryValueIndex.ContainsKey(val))
        {
            return;
        }

        var index = _dictionaryValueIndex[val];
        (_values[index], _values[^1]) = (_values[^1], _values[index]);
        
        _dictionaryValueIndex[_values[index]] = index;
        _values.RemoveAt(_values.Count - 1);
        _dictionaryValueIndex.Remove(val);
    }
    
    public GameNode GetRandom() 
    {
        var index = Random.Range(0,_values.Count);
        return _values[index];
    }
}