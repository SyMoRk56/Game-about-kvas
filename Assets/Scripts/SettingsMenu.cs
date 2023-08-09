using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider slider;
    public static float volume = 0.99f;
    public AudioMixer mix;
    public AudioSource cheatSource, buttonSource;
    private void Start()
    {
        slider.value = volume;
    }
    public void ChangeVolume()
    {
        volume = slider.value;
        mix.SetFloat("Volume", volume * 50 - 50);

    }
    public void ToMain()
    {
        buttonSource.Play();
        SceneManager.LoadScene(0);
    }
    public void CheatSound()
    {
        cheatSource.Play();
    }
}
