/*
    Klasa odpowiadająca za Menu Główne (Main Menu).
    Na początku wszystkie okna są wyłączane.
    Jeśli wciśniemy przcisk Quit, program zostanie zamknięty.
    Jeśli wciśniemy przycisk Play, zostanie załadowana scena rozgrywki i rozgrywka się rozpocznie.
    W przypadku pozostałych przycisków, po ich wciśnięciu wyświetli się odpowiednie okno 
    (przypisane jako dziecko o indeksie 1 danego przycisku). 
    Jeśli w oknie wciśniemy przycisk Back, okno się zamknie o powrócimy do Menu Głównego.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameObject[] panels;
    GameObject[] mmButtons;

    void Start() 
    {
        panels = GameObject.FindGameObjectsWithTag("subpanel");
        mmButtons = GameObject.FindGameObjectsWithTag("mmbutton");

        foreach (GameObject p in panels)
            p.SetActive(false);
    }

    public void ClosePanel(Button button)
    {
       button.gameObject.transform.parent.gameObject.SetActive(false);
       foreach (GameObject b in mmButtons)
            b.SetActive(true);
    }

    public void OpenPanel(Button button)
    {
         button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
         foreach (GameObject b in mmButtons)
            if(b != button.gameObject)
                b.SetActive(false);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        PlayerState.isPlaying = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
