using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Limiter les FPS à 60
        Application.targetFrameRate = 60;
    }

}
