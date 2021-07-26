using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LogController : MonoBehaviour
{
    [SerializeField]
    private GameObject log;
    [SerializeField]
    private GameObject logElementPrefab;
    
    private List<LogElement> _logElements;

    private void CreateLogElement()
    {
        var newLogElement = Instantiate(logElementPrefab, log.transform, false);
        var toAdd = newLogElement.AddComponent<LogElement>();
    }

    void Start()
    {
        CreateLogElement();
        CreateLogElement();
        CreateLogElement();
        CreateLogElement();
    }

    void Update()
    {
        
    }
}
