using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CasePanel : MonoBehaviour
{
    public Animator animator;
    public TMP_Text nameT, quaT;
    public Image kvasImage;
    public void Show(string KvasName,string KvasQuality, Sprite icon)
    {
         nameT.text = KvasName;
         quaT.text = "Цена: "+KvasQuality;
          kvasImage.sprite = icon;


        animator.SetTrigger("On");
    }
}
