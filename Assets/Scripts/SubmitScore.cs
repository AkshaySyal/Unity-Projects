using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitScore : MonoBehaviour
{
    
    void Start()
    {
        var user = new User();
        var gsObj=FindObjectOfType<GameSession>();
        user.name = User.currname;
        user.score = gsObj.ReportScore();

        DatabaseHandler.PostUser(user, () => { });

    }
    

}
