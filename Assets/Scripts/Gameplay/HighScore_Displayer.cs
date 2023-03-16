using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore_Displayer : MonoBehaviour
{
    private TextMeshProUGUI HighScore;

    void Start()
    {
        HighScore = GetComponent<TextMeshProUGUI>();
        HighScore.text = "High Score " + PlayerPrefs.GetInt("HighScore", 0);
    }

}
