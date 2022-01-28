using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    public Text lastScore;
    public Text highestScore;

    void OnEnable() 
    {
        if(PlayerPrefs.HasKey("lastscore"))
            lastScore.text = "Last Score: " + PlayerPrefs.GetInt("lastscore");
        else
            lastScore.text = "Last Score: 0";

        if(PlayerPrefs.HasKey("highscore"))
            highestScore.text = "High Score: " + PlayerPrefs.GetInt("highscore");
        else
            highestScore.text = "Highest Score: 0";
    }
}
