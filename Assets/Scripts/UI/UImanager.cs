using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get => instance; }
    public JoystickController MoveController;
    public JoystickController AttackController;

    private void Awake()
    {
        var objs = FindObjectsByType<UIManager>(FindObjectsSortMode.None);
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
        instance = this;
    }
}
