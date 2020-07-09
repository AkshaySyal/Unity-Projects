using System;

/// <summary>
/// The user class, which gets uploaded to the Firebase Database
/// </summary>

[Serializable] // This makes the class able to be serialized into a JSON
public class User
{
    public  string name;
    public int score;
    public  string localId;
    public static string currname="";
    public static string currlocalId="";
    public static string idToken = "";
}
