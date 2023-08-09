using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestButton : MonoBehaviour
{
    public void Destroy()
    {
        KvasManager.instance.sellTable.gameObject.SetActive(false);
    }
}
