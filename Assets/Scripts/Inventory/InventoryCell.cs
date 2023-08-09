using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class InventoryCell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Kvas currectItem;
    public Image image;
    public string currectName;
    public string currectDesc;
    public int currectRating;
    
    public int currectQuality;

    private void Start()
    {
        //currectItem = null;
        image = GetComponent<Image>();
        UpdateCell();
        
        
        

    }
    public void UpdateCell()
    {
        if (currectItem == KvasManager.instance.emptyKvas || currectItem ==null)
        {
            
            if (TryGetComponent<MenuItem>(out MenuItem n))
            {
                currectItem = KvasManager.instance.allKvass[PlayerPrefs.GetInt("M" + KvasManager.instance.kvasList.IndexOf(this))];

            }
            else if(TryGetComponent<InventoryItem>(out InventoryItem o)) currectItem = KvasManager.instance.allKvass[PlayerPrefs.GetInt("I" + InventoryManager.instance.inventoryCells.IndexOf(this))];
            else currectItem = KvasManager.instance.emptyKvas;
        }
        currectQuality = PlayerPrefs.GetInt("Q" + KvasManager.instance.kvasList.IndexOf(this), currectQuality);
        currectName = currectItem.name;
        currectDesc = currectItem.description;
        currectRating = currectItem.rating;


        image.sprite = currectItem.sprite;

        image.color = Color.white;
        if(image.sprite == null)
        {
            image.color = Color.clear;
        }

        if (TryGetComponent<MenuItem>(out MenuItem m))
        {
            PlayerPrefs.SetInt("M" + KvasManager.instance.kvasList.IndexOf(this), currectItem.index);

        }
        else PlayerPrefs.SetInt("I" + KvasManager.instance.kvasList.IndexOf(this), currectItem.index);
        PlayerPrefs.SetInt("Q" + KvasManager.instance.kvasList.IndexOf(this), currectQuality);
    }
    #region time
    float inputTime;
    bool isInput;
    void Update()
    {
        inputTime += Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isInput = true;
        inputTime = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(inputTime > 0.5f && isInput)
        {
            if (currectItem == null || currectItem == KvasManager.instance.emptyKvas) return;
            int price = (int)(currectItem.rating * 1.5f + currectQuality);
            KvasManager.instance.sellTable.gameObject.SetActive(true);
            KvasManager.instance.sellTable.kvasText.text = "Ты точно хочешь продать " + currectName + " за " + price + "?";
            KvasManager.instance.sellTable.tuple = (true, currectItem, price, this, TryGetComponent(out InventoryItem a));
            KvasManager.instance.sellTable.gameObject.transform.position = Input.mousePosition;
            isInput = false;
        }
        
    }
    #endregion
}
