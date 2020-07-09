using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //Serialised for debugging purposes
    [Range(0.5f, 1.3f)] [SerializeField] public float gameSpeed= 0.5f;
    int currLvl = 1;
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Level 1")
                SceneManager.LoadScene("Level 2");
            if (SceneManager.GetActiveScene().name == "Level 2")
            {
                SceneManager.LoadScene("Win Scene");
            }
            currLvl++;
        }

    }
}

