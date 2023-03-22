using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Manager : MonoBehaviour
{
    private TextMeshProUGUI ScoreCounterText;
    public static int ScoreValue = 0;


    private void Awake()
    {
        ScoreCounterText = GetComponent<TextMeshProUGUI>();
        ScoreValue = 0;
    }
   
    void Update()
    {
        ScoreCounterText.text = ScoreValue.ToString();   
    }
}
