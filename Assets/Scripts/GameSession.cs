using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameSession : MonoBehaviour
{
    
    [SerializeField] int pointsPerBlockDestroyed = 100;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip audioClip;
   

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    


    private void Start()
    {
        scoreText.text =  currentScore.ToString();
    }

    

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        
        Destroy(gameObject);

    }

    public int ReportScore()
    {
        return int.Parse(scoreText.text);
    }

    
}
