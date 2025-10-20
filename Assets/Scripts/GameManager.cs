using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public static int score;

    void Start()
    {
        score = 0;
        bestScore = 0;

        // Limiter les FPS à 60
        Application.targetFrameRate = 60;
    }
}
