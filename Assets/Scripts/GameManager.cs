using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [Header("UI")]
    [SerializeField] private TMP_Text scoreValueText;
    [SerializeField] private TMP_Text bestScoreValueText;
    [SerializeField] private TMP_Text ballLeftText;
    [SerializeField] private GameObject gameOverMenu;

    [Header("Scores")]
    public int score;
    public int bestScore = 0;
    public int ballLeft;

    void Start()
    {
        // Charger le meilleur score sauvegard�
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        score = 0;
        ballLeft = 2;   // Le joueur d�marre avec 3 balls (il lui en reste donc 2 apr�s celle actuelle)

        gameOverMenu.SetActive(false);

        mainCamera.backgroundColor = new Color32(132, 132, 132, 255);

        // Limiter les FPS � 60
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        UpdateUI();

        if (Input.GetKeyDown(KeyCode.Space) && gameOverMenu.activeSelf)
        {
            PlayAgain();
        }
    }

    // Ajoute un certain montant au score et v�rifie si on bat le record.
    public void AddScore(int amount)
    {
        score += amount;

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);  // Sauvegarde persistante
            PlayerPrefs.Save();
        }
    }

    // Met � jour l'affichage des scores sur le HUD.
    private void UpdateUI()
    {
        scoreValueText.text = score.ToString("D7");
        bestScoreValueText.text = bestScore.ToString("D7");
        ballLeftText.text = ballLeft.ToString();
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        mainCamera.backgroundColor = new Color32(15, 15, 15, 255);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

