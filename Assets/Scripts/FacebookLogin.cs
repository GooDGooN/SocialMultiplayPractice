using UnityEngine;
using Facebook.Unity;
using System.Collections.Generic;
using TMPro;
public class FacebookLogin : MonoBehaviour
{
    public TMP_Text StatusText;
    private void Awake()
    {
        if(FB.IsInitialized)
        {
            FB.ActivateApp();
            SendStatusMessage("ActiveApp");
        }
        else
        {
            FB.Init(InitCallback, OnHideUnity);

            void InitCallback()
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                    SendStatusMessage("Facebook SDK initialize successed");
                }
                else
                {
                    SendStatusMessage("Facebook SDK initialize failed");
                }
            }

            void OnHideUnity(bool isResumeable)
            {
                if (isResumeable)
                {
                    Time.timeScale = 1.0f;
                }
                else
                {
                    Time.timeScale = 0.0f;
                }
            }
        }   
    }

    public void LoginButtonClick()
    {
        List<string> permissions = new () { "public_profile", "email" };
        SendStatusMessage("button clicked");
        FB.LogInWithReadPermissions(permissions, (ILoginResult result) =>
        {
            if (FB.IsLoggedIn)
            {
                var accessToken = AccessToken.CurrentAccessToken;
                SendStatusMessage($"user id : {accessToken.UserId}");
            }
            else
            {
                SendStatusMessage("Login canceled");
            }
        });

    }

    public void SendStatusMessage(string message)
    {
        StatusText.text = message;
    }
}
