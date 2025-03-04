using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Object
{
    protected static T instance;
    public static T Instance { get => instance; }

    protected void Awake()
    {
        instance = this as T;
        var objs = FindObjectsByType<T>(FindObjectsSortMode.None);
        if(objs.Length > 1)
        {
            foreach(var obj in objs)
            {
                if(obj != this)
                {
                    Destroy(obj);
                }
            }
        }
    }
}
