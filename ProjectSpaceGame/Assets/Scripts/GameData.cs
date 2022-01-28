using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public static GameData singleton;
    int score = 0;
    int distance = 0;

    private void Awake() 
    {
        GameObject[] gd = GameObject.FindGameObjectsWithTag("GameData");

        if (gd.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        singleton = this;

        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("distance", 0);
        PlayerPrefs.SetInt("finalScore", 0);
    }

    void Update() 
    {
        if (!PlayerState.isDead)
        {
            distance = (int) PlayerState.distance;
            PlayerPrefs.SetInt("distance", distance);
        }

        if (!PlayerPrefs.HasKey("highscore"))
            PlayerPrefs.SetInt("highscore", 0);

        if (!PlayerPrefs.HasKey("lastscore"))
            PlayerPrefs.SetInt("lastscore", 0);
    }

    public void UpdateScore(int s)
    {
        score += s;
        PlayerPrefs.SetInt("score", score);
    }
}
