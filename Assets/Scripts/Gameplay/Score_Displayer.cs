using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Displayer : MonoBehaviour
{
    private TextMeshProUGUI CurrentScore;

    void Start()
    {
        CurrentScore = GetComponent<TextMeshProUGUI>();
        CurrentScore.text = "Current Score " + Score_Manager.ScoreValue.ToString();
    }

}
