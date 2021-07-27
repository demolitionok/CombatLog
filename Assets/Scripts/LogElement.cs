using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public delegate void OnDestroy();
public class LogElement : MonoBehaviour
{
    public float LifeTime;
    public string Text; 
    public Color Color;

    public event OnDestroy OnDestroy;

    public LogElement()
    {
        LifeTime = 5f;
        Text = "empty";
        Color = Color.magenta;
    }

    public IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(LifeTime);
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }

    public LogElement(float lifeTime, string text, Color color)
    {
        LifeTime = lifeTime;
        Text = text;
        Color = color;
    }
}
