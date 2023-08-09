using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource butttonSource;
    public GameObject inventoryMenu;
    public GameObject MainMenu;
    public GameObject caseMenu;
    KvasManager kvasManager;
    public TMP_Text moneyText;
    public static GameManager instance;

    public Animator caseAnimator, inventoryAnimator;
    public Animator tooltypeAnimator;

    public int money = 0;
    int AddMoney;

    public TMP_Text tooltype;
    public Image toolImage;
    public int buff;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        
        money = PlayerPrefs.GetInt("Money");
        
        kvasManager = FindObjectOfType<KvasManager>();
        InvokeRepeating("UpdateMoney", 1f, 1f);
        //ToMain();
        CombinationCheck.Instance.CheckCombinations();
    }

    bool inMenu = true;
    #region bottons
    public void ToInv()
    {
        butttonSource.Play();
        if (inMenu)
        {
            inventoryAnimator.ResetTrigger("Off");
            inventoryAnimator.SetTrigger("On");
            inMenu = false;
        }
        else ToMain();
    }
    public void ToMainMenu()
    {
        butttonSource.Play();
        SceneManager.LoadScene(0);
    }
    public void ToMain()
    {
        
        caseAnimator.SetTrigger("Off");
        inventoryAnimator.SetTrigger("Off");
        
        inMenu = true;
    }
    public void ToCase()
    {
        butttonSource.Play();
        if (inMenu)
        {
            caseAnimator.ResetTrigger("Off");
            caseAnimator.SetTrigger("On");
            inMenu = false;
        }
        else ToMain();
        
        //inventoryAnimator.SetTrigger("Off");
        
    }
        #endregion
        void UpdateMoney()
        {
        for(int i = 0; i < KvasManager.instance.kvasList.Count; i++)
        {
            AddMoney += (int)(kvasManager.kvasList[i].currectQuality * 0.25f + kvasManager.kvasList[i].currectRating * 0.5f) * (buff / 100 + 1);
            if (AddMoney == 0 && kvasManager.kvasList[i].currectItem != kvasManager.emptyKvas) AddMoney = 1;
        }
        
            
        
            money += AddMoney;
            moneyText.text = "Крышечек:"+money.ToString();
            
            AddMoney = 0;
        PlayerPrefs.SetInt("Money", money);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Reset");
            PlayerPrefs.DeleteAll();
        } 
    }
}

