using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combinalion")]
public class Combinations : ScriptableObject
{
    public List<Kvas> itemsInCombinations = new List<Kvas>(3);
    public int Buff;
}
