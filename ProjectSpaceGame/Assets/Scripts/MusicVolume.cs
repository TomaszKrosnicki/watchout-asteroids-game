/*
    Klasa odpowiedzialna za zapisywanie ustawień głośności muzyki w Menu Opcji
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider slider;
    public float musicVolume;
    void OnEnable()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume", musicVolume);
    }

    public void UpdateMusicVolume(float value)
    {
        musicVolume = value;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }
}
