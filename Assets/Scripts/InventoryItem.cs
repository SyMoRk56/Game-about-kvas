using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryItem : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    bool isInput;
    float inputTime;
    void Update()
    {
        inputTime += Time.deltaTime;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isInput && inputTime < 0.5f)
        {
            if (gameObject.GetComponent<InventoryCell>().currectItem != null)
            {
                //Debug.Log("A");
                //Debug.Log(InventoryManager.instance.inventoryCells.IndexOf(gameObject.GetComponent<InventoryCell>()));

                KvasManager.instance.AddItem(gameObject.GetComponent<InventoryCell>().currectItem, gameObject.GetComponent<InventoryCell>().currectQuality);
                InventoryManager.instance.RemoveItem(InventoryManager.instance.inventoryCells.IndexOf(gameObject.GetComponent<InventoryCell>()));

            }
        }
        isInput = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        inputTime = 0;
        isInput = true;
    }
}

    

