using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Limiter les FPS � 60
        Application.targetFrameRate = 60;
    }

}
