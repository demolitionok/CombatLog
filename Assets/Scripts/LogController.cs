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
    private List<LogElement> _logElements;

    private LogElement InstantiateLogElement(Vector3 offset)
    {
        var newLogElement = Instantiate(logElementPrefab, log.transform, false);
        newLogElement.GetComponent<RectTransform>().position += offset;
        return newLogElement.AddComponent<LogElement>();
    }

    private int RegisterLogElement(LogElement elem)
    {
        if(_logElements.Count + 1 <= maxSize)
            _logElements.Add(elem);
        else
        {
            DestroyLogElementById(0);
            _logElements.Add(elem);
        }

        return _logElements.Count - 1;
    }

    public void CreateLogElement(string text, Color color, float lifetime)
    { 
        var elem = InstantiateLogElement(_logElements.Count * Vector3.down * logElementPrefab.GetComponent<RectTransform>().rect.height);
        elem.Text = text;
        elem.Color = color;
        elem.LifeTime = lifetime;
        
        SetLogGameObject(elem);
        var id = RegisterLogElement(elem);
        StartCoroutine(DestroyByIdWithDelay(id));
    }

    private GameObject SetLogGameObject(LogElement elem)
    {
        var result = elem.gameObject;
        result.GetComponent<Image>().color = elem.Color;
        var textGameObj = result.transform.GetChild(0).gameObject;
        textGameObj.GetComponent<Text>().text = elem.Text;
        return result;
    }

    private void DestroyLogElementById(int id)
    {
        var elem = _logElements[id];
        _logElements.RemoveAt(id);
        Destroy(elem.gameObject);
    }

    private IEnumerator DestroyByIdWithDelay(int id)
    {
        var elem = _logElements[id];
        yield return new WaitForSeconds(elem.LifeTime);
        DestroyLogElementById(id);
    }

    private void Awake()
    {
        _logElements = new List<LogElement>();
    }
}
