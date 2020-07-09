using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loaderscript : MonoBehaviour
{
    GameSession gameObj;

    public void LoadLB()
    {
        try
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
        catch(Exception e) { }
        SceneManager.LoadScene("LeaderBoard");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLvl1()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Level 1");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void Loader()
    {
        SceneManager.LoadScene("Homescr");
    }

    public void LoseScreen()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Lose Scene");
      
    }

    public void WinScreen()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Win Scene");
    }

    public void LoadLvl2()
    {
      SceneManager.LoadScene("Level 2");
    }

    public void LoadInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void LoadHomescr()
    {
        SceneManager.LoadScene("Homescr");
    }

}
