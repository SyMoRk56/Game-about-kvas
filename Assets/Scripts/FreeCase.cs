using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FreeCase : MonoBehaviour
{
    Case thisCase;
    int Count = 1;
    public TMP_Text countText;
    private void Start()
    {
        PlayerPrefs.SetInt("FreeCount", Count);
        thisCase = GetComponent<Case>();
        countText.text = "Осталось: " + Count.ToString();
    }
    public void Click()
    {
        if(Count > 0)
        {
            Count--;
            thisCase.Open();
            countText.text = "Осталось: " + Count.ToString();
            PlayerPrefs.SetInt("FreeCount", Count);
            PlayerPrefs.Save();
        }
    }
}
