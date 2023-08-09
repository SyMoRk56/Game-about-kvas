using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
[CreateAssetMenu(fileName = "Kvas")]

public class Kvas : ScriptableObject
{
    public string name;
    public string description;
    public int rating;
    
    public int index;
    
    public Sprite sprite;
}
