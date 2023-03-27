using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    int newhighscore;

    public void SetHighScore(string input)
    {
        int.TryParse(input, out newhighscore);
        PlayerPrefs.SetInt("HighScore", newhighscore);
    }
}
