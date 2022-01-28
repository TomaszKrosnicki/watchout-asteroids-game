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
        exitToMenu = true;
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
    }

}
