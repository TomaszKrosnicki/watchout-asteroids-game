/*
    Klasa odpowiada za wyświetlanie statystyk w trakcie gry oraz w oknie Końca Gry
    *   Score (punkty za gwiazdki)
    *   FinalScore (wynik końcowy, czyli suma punktów za gwiazdki oraz za dystans)
    *   Distance (punkty za dystans)
    *   Fuel (stan paliwa)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Text[] distance;
    public Text score;
    public Text finalscore;
    public Text fuel;

    private void Update()
    {

        if (PlayerPrefs.HasKey("score"))
            score.text = "" + PlayerPrefs.GetInt("score");
        else
            score.text = "0";

        if (PlayerPrefs.HasKey("finalScore"))
            finalscore.text = "Final Score: " + PlayerPrefs.GetInt("finalScore");
        else
            finalscore.text = "0";
        
        if (PlayerPrefs.HasKey("distance"))
            for(int i = 0; i < distance.Length; i++)
            distance[i].text = "Distance: " + PlayerPrefs.GetInt("distance");
        else
            for(int i = 0; i < distance.Length; i++)
            distance[i].text = "Distance: 0";

        fuel.text = "" + PlayerState.fuel;
    }
}
