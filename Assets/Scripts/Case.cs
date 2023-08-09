using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class Case : MonoBehaviour
{
    public AudioSource openSound;
    public int price;
    public CaseItem[] items;
    List<CaseItem> thisItems = new List<CaseItem>();
    public CasePanel casePanel;
    public Animator TabloAnim;
    //CaseItem[] test = new CaseItem[10];
    KvasManager kvasManager;
    public int maxQuality;
    private void Start()
    {
        
        kvasManager = FindObjectOfType<KvasManager>();
    }
    public void Open()
    {
        System.Tuple<bool, int> tuple = InventoryManager.instance.GetFreeCell();
        if (GameManager.instance.money >= price && tuple.Item1)
        {
            
            GameManager.instance.money -= price;
            
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < items[i].change; j++)
                {
                    thisItems.Add(items[i]);
                }
            }
            int rand = Random.Range(0, thisItems.Count);
            DropItem(thisItems[rand].kvas);
            thisItems.Clear();
        }
        else
        {
            TabloAnim.SetTrigger("On");
        }
        
        
        
    }

    private void DropItem(Kvas kvas)
    {
        if (kvas.name == null) Debug.Log("Name");
        if (kvas.sprite == null) Debug.Log("Spr");
        
        int rand = Random.Range(0, maxQuality);
        casePanel.Show(kvas.name,rand.ToString(),kvas.sprite);
        openSound.Play();
        KvasManager.instance.AddItem(kvas,rand);
    }

}
