using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FullSerializer;
using Proyecto26;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class authScript : MonoBehaviour
{
   

    public InputField SUemailText;
    public InputField SUusernameText;
    public InputField SUpasswordText;
    public GameObject panel;

    public InputField SIemailText;
    public InputField SIpasswordText;
    private string idtoken;
    

    User user = new User();
    UserNames un = new UserNames();
    private string databaseURL = "https://first-17361.firebaseio.com/users";
    private string AuthKey = "kagaz nahi dikhayenge";
    private string dburl = "https://first-17361.firebaseio.com/usernames";
    public static fsSerializer serializer = new fsSerializer();


    public static int playerScore;
    public static string playerName;

   

    public static string localId;

    private string getLocalId;
    public bool goahead = true;
    bool val = false;





    public void msg()
    {
        panel.gameObject.SetActive(false);
    }


    
    

   

    public void SignInUserButton()
    {
        SignInUser(SIemailText.text, SIpasswordText.text);
    }

    public void SignUpUserButton()
    {
        Check(SUusernameText.text);
    }

    private void Check(string username)
    {
        
        RestClient.Get<UserNames>(dburl+"/"+username+".json").Then(user => {
            Debug.Log(user.name);
            val = true;
            DoubleCheck();
        }).Catch(error =>
        {
            DoubleCheck();
        });

        
        
    }
    
    private void DoubleCheck()
    {
        if (val)
        {
            Debug.Log("User exists");
            val = false;
            panel.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("User doesn't exist");
            SignUpUser(SUemailText.text, SUusernameText.text, SUpasswordText.text);
        }
    }
    

    private void SignUpUser(string email, string username, string password)
    {
        

        
            Debug.Log("Posting tak");
            string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
            RestClient.Post<SignResponse>("https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=" + AuthKey, userData).Then(
                response =>
                {
                    idtoken = response.idToken;
                    localId = response.localId;
                    playerName = username;
                    User user = new User();
                    UserNames un = new UserNames();
                    un.name = username;
                    user.name = username;
                    user.score = 0;
                    user.localId = localId;
                    RestClient.Put(dburl + "/" + username + ".json?auth=" + idtoken, un);
                    RestClient.Put(databaseURL + "/" +  localId + ".json?auth=" + idtoken, user);
                    User.currname = user.name;
                    User.currlocalId = user.localId;
                    User.idToken = idtoken;
                    SceneManager.LoadScene("Homescr");
      
                }).Catch(error =>
                {
                    Debug.Log(error);
                });
        

    }

    private void SignInUser(string email, string password)
    {
        string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
        RestClient.Post<SignResponse>("https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key="+AuthKey, userData).Then(
            response =>
            {
                Debug.Log("Working");
                idtoken = response.idToken;
                localId = response.localId;
                User.idToken = idtoken;
                GetUsername();

            }).Catch(error =>
            {
                Debug.Log("HELL NO");
                Debug.Log(error);
            });
    }
    
    public void Load()
    {
        SceneManager.LoadScene("Homescr");
    }

    private void GetUsername()
    {
        Debug.Log("GetUsername out");
        RestClient.Get<User>(databaseURL + "/" + localId + ".json?auth="+idtoken).Then(response =>
        {
            Debug.Log("GetUsername");
            User.currname = response.name;
           
            SceneManager.LoadScene("Homescr");
        });
    }

    public void OnFPclick()
    {
        string email = SIemailText.text;
        ForgotPassword(email);
    }

    private void ForgotPassword(string email)
    {
        string data = "{\"requestType\":\"" + "PASSWORD_RESET" + "\",\"email\":\"" + email + "\"}";
        RestClient.Post<FPclass>("https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + AuthKey, data).Then(
            response =>
            {
                Debug.Log(response.email);
                Debug.Log("Works??Maybe...");
            }).Catch(error =>
            {
                Debug.Log(error);
            });
       
    

    }


}
