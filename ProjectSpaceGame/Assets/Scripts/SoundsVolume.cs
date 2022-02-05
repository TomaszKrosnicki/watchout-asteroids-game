/*
    Klasa odpowiedzialna za zapisywanie ustawień głośności dźwięków w Menu Opcji
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsVolume : MonoBehaviour
{
    public Slider slider;
    public float soundsVolume;
    void OnEnable()
    {
        slider.value = PlayerPrefs.GetFloat("soundsVolume", soundsVolume);
    }

    public void UpdateSoundsVolume(float value)
    {
        soundsVolume = value;
        PlayerPrefs.SetFloat("soundsVolume", soundsVolume);
    }
}
