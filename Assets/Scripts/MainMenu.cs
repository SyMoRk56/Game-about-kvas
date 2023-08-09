using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonSource;
    public GameObject DeadPartSyst;
    public static MainMenu instance;
    public AudioSource sound;
    public GameObject howToPlayObj;
    private void Start()
    {
        instance = this;
    }
    public void ToGame()
    {
        buttonSource.Play();
        SceneManager.LoadScene(1);
    }
    public void ToSettings()
    {
        buttonSource.Play();
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void howToPlay()
    {
        buttonSource.Play();
        howToPlayObj.SetActive(true);
    }
    public void howToPlayCalcel()
    {
        buttonSource.Play();
        howToPlayObj.SetActive(false);
    }
}
