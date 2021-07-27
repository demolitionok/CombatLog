using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class LogController : MonoBehaviour
{
    [SerializeField]
    private GameObject log;
    [SerializeField]
    private GameObject logElementPrefab;

    [SerializeField]
    private int maxSize;
    private LogElemDict _logElements;

    private LogElement InstantiateLogElement()
    {
        var newLogElement = Instantiate(logElementPrefab, log.transform, false);
        var toAdd = newLogElement.AddComponent<LogElement>();
        return toAdd;
    }

    private void SetPosition(LogElement elem, Vector3 newPosition)
    {
        elem.gameObject.GetComponent<RectTransform>().position = newPosition;
    }

    private string RegisterLogElementWithKey(string key,LogElement elem)
    {
        if (_logElements.Count + 1 <= maxSize)
        {
            _logElements.Add(key, elem);
            elem.OnDestroy += () =>
            {
                _logElements.Remove(key);
            };
        }
        else
        {
            var firstKey = _logElements.First().Key;
            _logElements.RemoveWithCoroutineStop(firstKey);
            _logElements.Add(key, elem);
        }
            
        return key;
    }

    public void CreateLogElement(string key, string text, Color color, float lifetime)
    {
        var height = logElementPrefab.GetComponent<RectTransform>().rect.height;
        var elem = InstantiateLogElement();
        elem.Text = text;
        elem.Color = color;
        elem.LifeTime = lifetime;
        
        SetLogGameObject(elem); 
        RegisterLogElementWithKey(key, elem);
        SetPosition(elem,  log.transform.position + Vector3.down*(height*_logElements.Count));
    }

    private void SetLogGameObject(LogElement elem)
    {
        var result = elem.gameObject;
        result.GetComponent<Image>().color = elem.Color;
        var textGameObj = result.transform.GetChild(0).gameObject;
        textGameObj.GetComponent<Text>().text = elem.Text;
    }
    
    private void Awake()
    {
        _logElements = new LogElemDict();
    }
}
