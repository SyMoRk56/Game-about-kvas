using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class tooltype : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InventoryManager inventoryManager;
    InventoryCell cell;
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        
        cell = GetComponent<InventoryCell>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(GetComponent<InventoryCell>().currectItem != null && GetComponent<InventoryCell>().currectItem != KvasManager.instance.emptyKvas)
        {


            inventoryManager.tooltypeAnim.ResetTrigger("Off");
            inventoryManager.tooltypeAnim.SetTrigger("On");
            inventoryManager.toolText.text = cell.currectName;
            inventoryManager.toolDesc.text = cell.currectDesc;
            inventoryManager.toolRating.text = "–ейтинг:" + cell.currectRating.ToString();
            inventoryManager.toolQuality.text = "¬кус: "+cell.currectQuality.ToString();
            inventoryManager.toolIcon.sprite = cell.currectItem.sprite;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryManager.tooltypeAnim.ResetTrigger("On");
        inventoryManager.tooltypeAnim.SetTrigger("Off");
    }

   
}
