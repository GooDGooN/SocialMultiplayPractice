using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public readonly (float, float) MapSize = (18.0f, 9.0f); // width, height
    public GameObject IDContainer;
    private void Start()
    {
        
    }
}
