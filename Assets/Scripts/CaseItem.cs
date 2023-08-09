using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CaseItem")]
public class CaseItem : ScriptableObject
{
        public Kvas kvas;
        public int change;
        public int minCount, maxCount;
}
