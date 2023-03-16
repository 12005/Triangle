using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
     public void playGame()
     {
        SceneManager.LoadScene(1); 
     }
     
     public void quitGame()
    {
        Application.Quit();
    }

    public void retry()
    {
        SceneManager.LoadScene(1);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
