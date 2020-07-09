using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseCollider : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        SceneManager.LoadScene("Lose Scene");
    }

    
}
