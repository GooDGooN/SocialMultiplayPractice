using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    private int targetWidth = 1280;

    private void Awake()
    {
        DontDestroyOnLoad(this);

    }
    private void OnEnable()
    {
        var screenWidth = Screen.width;
        var screenHeight = Screen.height;
        var ratio = (float)screenHeight / screenWidth;
        Screen.SetResolution(targetWidth, (int)(ratio * targetWidth), true);
    }

}
