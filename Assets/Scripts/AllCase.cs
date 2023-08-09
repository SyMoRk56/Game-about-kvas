using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCase : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    int curSpr;

    private void Start()
    {
        InvokeRepeating("Repeat", 0.15f, 0.15f);
    }
    void Repeat()
    {
        image.sprite = sprites[curSpr];
        
        if (curSpr == sprites.Length - 1)
        {
            curSpr = 0;
        }
        else curSpr++;
        
    }
    
}
