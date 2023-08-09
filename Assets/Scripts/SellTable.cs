using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellTable : MonoBehaviour
{
    public TMP_Text kvasText;
    public (bool,Kvas,int,InventoryCell,bool) tuple;

    public void Sell()
    {
        if (tuple.Item1 && tuple.Item2)
        {
            if (tuple.Item5)
            {
                InventoryManager.instance.RemoveItem(InventoryManager.instance.inventoryCells.IndexOf(tuple.Item4));
                //InventoryManager.instance.inventoryCells[InventoryManager.instance.inventoryCells.IndexOf(tuple.Item4)].currectItem = KvasManager.instance.emptyKvas;
                
            }
            else 
            {
                KvasManager.instance.RemoveItem(KvasManager.instance.kvasList.IndexOf(tuple.Item4));
                //KvasManager.instance.kvasList[KvasManager.instance.kvasList.IndexOf(tuple.Item4)].currectItem = KvasManager.instance.emptyKvas;
                
            }
            GameManager.instance.money += tuple.Item3;
            
            tuple.Item1 = false;
            Destroy();
            InventoryManager.instance.UpdateCells();
            KvasManager.instance.UpdateCells();
        }
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
