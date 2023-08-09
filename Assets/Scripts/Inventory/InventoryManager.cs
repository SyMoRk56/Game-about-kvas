using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Kvas> allKvass;

    public int vecticalScale, horizontalScale;
    public List<InventoryCell> inventoryCells = new List<InventoryCell>();
    public GameObject itemPrefab;
    public Transform content;
    public static InventoryManager instance;
    public int maxCount = 21;

    public Animator tooltypeAnim;
    public GameObject tooltype;
    public TMP_Text toolText;
    public TMP_Text toolDesc;
    public TMP_Text toolRating;
    public TMP_Text toolQuality;
    public Image toolIcon;

    void Awake()
    {
        
        instance = this;
        fillInventory();
    }
    private void Start()
    {
        
    }

    public void fillInventory()
    {
        for(int i = 0; i < vecticalScale*horizontalScale; i++)
        {
            InventoryCell cell = Instantiate(itemPrefab, content).GetComponent<InventoryCell>();
            inventoryCells.Add(cell);
            cell.AddComponent<InventoryItem>();
            cell.AddComponent<tooltype>();
        }
    }
    public Tuple<bool, int> GetFreeCell()
    {
        for(int i = 0;i < inventoryCells.Count;i++)
        {
            if (inventoryCells[i].currectItem == null || inventoryCells[i].currectItem == KvasManager.instance.emptyKvas)
            {
                return Tuple.Create(true, i);
            }
        }
        return Tuple.Create(false, 0);
    }
    public void AddItem(Kvas kvas,int cellId)
    {
        inventoryCells[cellId].currectItem = kvas;
        UpdateCells();
        
        
    }
    public void RemoveItem(int cellId)
    {
        inventoryCells[cellId].currectItem = null;
        PlayerPrefs.SetInt("M" + cellId, 0);
        UpdateCells();
        
    }
    
    
    public void UpdateCells()
    {
       
        for (int i = 0;i < inventoryCells.Count; i++)
        {
            Debug.Log(i);
            inventoryCells[i].UpdateCell();
        }
        
        PlayerPrefs.Save();
    }
}
