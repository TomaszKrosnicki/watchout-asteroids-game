using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public static bool isDead = false;
    public static bool isPlaying = true;
    public static float countOne = 0;
    public static float countTen = 0;
    public static float distanceMultiplyer = 1;
    public static float distance = 0;
    public static int fuel = 50;
    Animator anim;
    public GameObject pausePanel;
    public Text highScore;
    
    void Start()
    {
        anim = this.GetComponent<Animator>();
        pausePanel.SetActive(false);
        if(PlayerPrefs.HasKey("highscore"))
            highScore.text = "High Score: " + PlayerPrefs.GetInt("highscore");
        else
            highScore.text = "High Score: 0";
    }

    void Update()
    {
        Pause();
        if (isDead || GameMenu.gm.exitToMenu) 
        {
            countOne = 0f;
            countTen = 0f;
            distanceMultiplyer = 1f;
            distance = 0f;
            fuel = 50;
            int a = PlayerPrefs.GetInt("score");
            int b = PlayerPrefs.GetInt("distance");
            int c = a + b;
            PlayerPrefs.SetInt("finalScore", c);
            if(PlayerPrefs.HasKey("lastscore"))
            {
                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("finalScore"));
            }
            if(PlayerPrefs.HasKey("highscore"))
            {
                int hs = PlayerPrefs.GetInt("highscore");
                if (hs < PlayerPrefs.GetInt("lastscore"))
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("lastscore"));
            }
            else
            {
                int hs = 0;
                PlayerPrefs.SetInt("highscore", hs);
            }
            return;
        }
        else if (!isPlaying)
        {
            return;
        }

        if(fuel == 0)
            isDead = true;

        GoLeft();
        GoRight();
        GoUp();
        GoDown();

        countOne += Time.deltaTime;
        if (countOne >= 1f)
        {
            distance += 10 * distanceMultiplyer;
            fuel--;
            countOne = 0f;
        }
        countTen += Time.deltaTime;
        if (countTen >= 10f)
        {
            distanceMultiplyer = distanceMultiplyer + (distanceMultiplyer * 0.1f);
            countTen = 0f;
        }
    }

    public void GoLeft()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && isPlaying && !isDead && !anim.GetBool("goRight"))
        {
            anim.SetBool("goLeft", true);
        }
        else
        {
            anim.SetBool("goLeft", false);
        }
    }

    public void GoRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && isPlaying && !isDead && !anim.GetBool("goLeft"))
        {
            anim.SetBool("goRight", true);
        }
        else
        {
            anim.SetBool("goRight", false);
        }
    }

    public void GoUp()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && isPlaying && !isDead && !anim.GetBool("goDown"))
        {
            anim.SetBool("goUp", true);
        }
        else
        {
            anim.SetBool("goUp", false);
        }
    }

    public void GoDown()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && isPlaying && !isDead && !anim.GetBool("goUp"))
        {
            anim.SetBool("goDown", true);
        }
        else
        {
            anim.SetBool("goDown", false);
        }
    }

    public void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isDead) return;
            if(pausePanel.activeInHierarchy == false)
            {
                pausePanel.SetActive(true);
                isPlaying = false;
            }
            else
                GameMenu.gm.ContinueGame();
        }
    }
}