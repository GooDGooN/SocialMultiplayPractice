using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Facebook.Unity;

public class FacebookUserInfo : MonoBehaviour
{
    public TMP_Text Text;

    private void Start()
    {
        if(FB.IsLoggedIn)
        {
            Text.text = GetFacebookID();
        }
    }

    public static string GetFacebookID()
    {
        return AccessToken.CurrentAccessToken.UserId;
    }
}
