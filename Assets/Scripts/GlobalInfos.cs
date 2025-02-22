using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;


public class FacebookUserInfo
{
    public readonly AccessToken Token;
    public FacebookUserInfo(AccessToken token)
    {
        Token = token;
    }
}

public class GlobalInfos : MonoBehaviour
{
   
    private static GlobalInfos instance;
    public static GlobalInfos Instance { get => instance; }

    public FacebookUserInfo FacebookUser;

    private void Awake()
    {
        var objs = GetComponents<GlobalInfos>();
        if (objs.Length > 1)
        {
            foreach(var obj in objs)
            {
                if(obj != this)
                {
                    Destroy(obj);
                }
            }
        }
        DontDestroyOnLoad(this);
        
    }

    public void InitializeFacebookInfo(AccessToken token)
    {
        FacebookUser = new FacebookUserInfo(token);
    }
}
