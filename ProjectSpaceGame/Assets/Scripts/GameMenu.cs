/*
    Klasa odpowiadająca za wyśiwietlanie okna Menu Pauzy oraz okna Game Over(Koniec Gry).
    Jeśli gracz przegra zostanie wyświetlone okno Game Over po 2 sekundach opóźnienia.
    Jeśli gracz zatrzyma grę zostanie wyświetlone okno Menu Pauzy.
    Jeśli gracz kontynuuje grę gra zostanie wznowiona po 2 sekundach opóźnienia (żeby dać czas na rękcję po powrocie do gry).
    Jeśli gracz wciśnie przycisk Play Again w oknie Game Over, scena jest wczytywana ponownie a zmienne są resetowane do początkowych wartości.
    Jeśli gracz wciśnie przycisk Main Menu w którymś z okien, wczytywana jest scena Menu Głównego(Main Menu) oraz resetowane są zmienne do początkowych wartośći.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static GameMenu gm;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public bool exitToMenu = false;

    void Awake() 
    {
        gm = this;    
    }
    void Start() 
    {
        gameOverMenu.SetActive(false);
    }
    void Update() 
    {
        if (PlayerState.isDead)
        {
            Invoke("GameOverDelay", 2f);
        }
    }

    void GameOverDelay()
    {
        gameOverMenu.SetActive(true);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        if(PlayerState.isDead)
            PlayerState.isDead = false;
        PlayerState.SetStatistics();
        exitToMenu = true;
        PlayerState.fuel = 50;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Invoke("DelayGameContinue", 2f);
    }

    void DelayGameContinue()
    {
        PlayerState.isPlaying = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        gameOverMenu.SetActive(false);
        PlayerState.isDead = false;
        PlayerState.fuel = 50;
    }

}
