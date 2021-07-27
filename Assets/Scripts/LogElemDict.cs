using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogElemDict
{
    private Dictionary<string, LogElement> _logElements;

    public LogElemDict()
    {
        Count = 0;
        _logElements = new Dictionary<string, LogElement>();
    }

    public int Count;

    public void GetIndexByKey(string key)
    {
        //_logElements[key].GetInstanceID(;
    }

    public void Add(string key, LogElement value)
    {
        value.StartCoroutine(value.SelfDestroy());
        _logElements.Add(key, value);
        Count++;
    }

    public void Remove(string key)
    {
        _logElements.Remove(key);
        Count--;
    }

    public void RemoveWithCoroutineStop(string key)
    {
        var elem = _logElements[key];
        if (elem != null)
        {
            elem.StopCoroutine(elem.SelfDestroy());
        }
        Remove(key);
    }

    public LogElement GetByKey(string key) => _logElements[key];
    

    public KeyValuePair<string, LogElement> First() => _logElements.First();
}