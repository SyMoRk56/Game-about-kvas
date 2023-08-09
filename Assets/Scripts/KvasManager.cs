using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class KvasManager : MonoBehaviour
{
    public List<Kvas> allKvass;

    public List<InventoryCell> kvasList = new List<InventoryCell>(3);
    public GameObject[] images;
    int a;
    public Kvas emptyKvas;
    public static KvasManager instance;
    
    public Sprite kvasanetyspr;

    public SellTable sellTable;

    private void Awake()
    {
        
    }
    private void Start()
    {
        
        instance = this;
        for (int i = 0; i < images.Length; i++)
        {
            kvasList[i] = images[i].GetComponent<InventoryCell>();
        }
        
       
    }
    
    public void UpdateCells()
    {
        for (int i = 0; i < images.Length; i++)
        {
            kvasList[i].UpdateCell();
            
        }
        
        PlayerPrefs.Save();
        CombinationCheck.Instance.CheckCombinations();
    }
    public void AddItem(Kvas kvas,int quality)
    {
        a = 0;
        for(int i = 0;i < images.Length; i++)
        {
            if (kvasList[i].currectItem == emptyKvas || kvasList[i].currectItem == null)
            {
                kvasList[i].currectItem = kvas;
                images[i].GetComponent<InventoryCell>().currectQuality = quality;
                UpdateCells();
                break;
            }
            else a++;
        }
        if(a >= 3)
        {
            Debug.Log("ADd");
            Tuple<bool, int> tuple = InventoryManager.instance.GetFreeCell();
            InventoryManager.instance.AddItem(kvas, tuple.Item2);
        }
    }
    public void RemoveItem(int index)
    {
        Debug.Log(index);
        
        Tuple<bool, int> tuple = InventoryManager.instance.GetFreeCell();
        InventoryManager.instance.AddItem(kvasList.ElementAt(index).currectItem, tuple.Item2);
        kvasList[index].currectItem = emptyKvas;
        PlayerPrefs.SetInt("M" + index,0);
        UpdateCells();
    }
    public Tuple<bool, int> GetFreeCell()
    {
        for (int i = 0; i < kvasList.Count; i++)
        {
            if (kvasList[i].currectItem == emptyKvas)
            {
                return Tuple.Create(true, i);
            }
        }
        return Tuple.Create(false, 0);
    }
    
}
