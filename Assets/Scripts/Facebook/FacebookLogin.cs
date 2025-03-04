using UnityEngine;
using Facebook.Unity;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
public class FacebookLogin : MonoBehaviour
{
    private void Start()
    {
        if(FB.IsInitialized)
        {
            FB.ActivateApp();
            StatusMessage.Instance.SendStatusMessage("ActiveApp");
        }
        else
        {
            FB.Init(InitCallback, OnHideUnity);

            void InitCallback()
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                    StatusMessage.Instance.SendStatusMessage("Facebook SDK initialize successed");
                }
                else
                {
                    StatusMessage.Instance.SendStatusMessage("Facebook SDK initialize failed");
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
        List<string> permissions = new() { "public_profile" };
        StatusMessage.Instance.SendStatusMessage("button clicked");
        FB.LogInWithReadPermissions(permissions, (ILoginResult result) =>
        {
            if (FB.IsLoggedIn)
            {
                var accessToken = AccessToken.CurrentAccessToken;
                StatusMessage.Instance.SendStatusMessage($"user id : {accessToken.UserId}");
                SceneManager.LoadScene(2);
            }
            else
            {
                StatusMessage.Instance.SendStatusMessage("Login canceled");
                StatusMessage.Instance.SendStatusMessage($"{result.Error}");
            }
        });

    }
}
