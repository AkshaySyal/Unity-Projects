using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class welcome : MonoBehaviour
{
    public Text player;
    void Start()
    {

        Display(); 
        
    }

    public void Display() {
        player.text = "Welcome " + User.currname;
    }
}
