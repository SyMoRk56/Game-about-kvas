using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UIElements;

public class MenuItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    KvasManager kvasManager;
    bool isInput;
    float inputTime;
    void Start()
    {
        kvasManager = FindObjectOfType<KvasManager>();
    }
    void Update()
    {
        inputTime += Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isInput  = true;
        inputTime = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        if(isInput && inputTime < 0.5f)
        {
            Tuple<bool, int> tuple = InventoryManager.instance.GetFreeCell();
            if (gameObject.GetComponent<InventoryCell>().currectItem != kvasManager.emptyKvas && gameObject.GetComponent<InventoryCell>().currectItem != null)
            {
                kvasManager.RemoveItem(KvasManager.instance.kvasList.IndexOf(gameObject.GetComponent<InventoryCell>()));
                //InventoryManager
            }
        }
        isInput = false;
    }
}
