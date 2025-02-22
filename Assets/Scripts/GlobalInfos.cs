using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class GlobalInfos : MonoBehaviour
{
    public static AccessToken FacebookUserToken;

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
}
