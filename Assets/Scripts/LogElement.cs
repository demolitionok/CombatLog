using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LogElement : MonoBehaviour
{
    public float LifeTime;
    public string Text; 
    public Color Color;

    public LogElement()
    {
        LifeTime = 5f;
        Text = "empty";
        Color = Color.magenta;
    }


    public LogElement(float lifeTime, string text, Color color)
    {
        LifeTime = lifeTime;
        Text = text;
        Color = color;
    }
}
