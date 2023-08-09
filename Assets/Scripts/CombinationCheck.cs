using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationCheck : MonoBehaviour
{
    public List<Combinations> combinations;
    public static CombinationCheck Instance;
    int count;
    int thisBuff;
    private void Awake()
    {
        Instance = this;
    }
    public int CheckCombinations()
    {
        thisBuff = 0;


        var itemList = KvasManager.instance.kvasList;
        for (int i = 0; i <combinations.Count; i++)
        {
            if (combinations[i].itemsInCombinations[0] == itemList[0].currectItem)
            {
                Debug.Log("1");
                if (combinations[i].itemsInCombinations[1] == itemList[1].currectItem)
                {
                    Debug.Log("$");
                    if (combinations[i].itemsInCombinations[2] == itemList[2].currectItem)
                    {
                        thisBuff = combinations[i].Buff;
                        Debug.Log("buff"+thisBuff);
                    }
                }
                if (combinations[i].itemsInCombinations[1] == itemList[2].currectItem)
                {
                    if (combinations[i].itemsInCombinations[2] == itemList[1].currectItem)
                    {
                        thisBuff = combinations[i].Buff;
                        Debug.Log("buff" + thisBuff);
                    }
                }
            }
            else if (combinations[i].itemsInCombinations[0] == itemList[1].currectItem)
            {
                Debug.Log("1");
                if (combinations[i].itemsInCombinations[1] == itemList[0].currectItem)
                {
                    if (combinations[i].itemsInCombinations[2] == itemList[2].currectItem)
                    {
                        thisBuff = combinations[i].Buff;
                        Debug.Log("buff" + thisBuff);
                    }
                }
                if (combinations[i].itemsInCombinations[1] == itemList[2].currectItem)
                {
                    if (combinations[i].itemsInCombinations[2] == itemList[0].currectItem)
                    {
                        thisBuff = combinations[i].Buff;
                        Debug.Log("buff" + thisBuff);
                    }
                }
            }

            else if (combinations[i].itemsInCombinations[0] == itemList[2].currectItem)
            {
                Debug.Log("1");
                if (combinations[i].itemsInCombinations[1] == itemList[1].currectItem)
                {
                    if (combinations[i].itemsInCombinations[2] == itemList[0].currectItem)
                    {
                        thisBuff = combinations[i].Buff;
                        Debug.Log("buff" + thisBuff);
                    }
                }
                if (combinations[i].itemsInCombinations[1] == itemList[0].currectItem)
                {
                    if (combinations[i].itemsInCombinations[2] == itemList[1].currectItem)
                    {
                        thisBuff = combinations[i].Buff;
                        Debug.Log("buff" + thisBuff);
                    }
                }
            }
            
        }
        return GameManager.instance.buff = thisBuff;
        

    }
}
