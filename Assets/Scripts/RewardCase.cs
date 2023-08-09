using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using YG;

public class RewardCase : MonoBehaviour
{
    
   

    YandexGame game;
    private void Start()
    {
        game = FindObjectOfType<YandexGame>();
        
    }
    public void OpenAdv()
    {
        game._RewardedShow(1);
    }
    public void OpenAdvCul()
    {
           
            GetComponent<Case>().Open();
            Debug.Log("Open");
        
    }
}
