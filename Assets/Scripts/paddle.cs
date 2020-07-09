using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    // Update is called once per frame
    
   
    void Update()
    {
        float mousePos = Input.mousePosition.x / Screen.width * 16f;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePos,1.44f,14.5f);
        transform.position = paddlePos;
        
    }
}
