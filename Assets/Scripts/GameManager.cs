using System.Collections.Generic;
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
        // Limiter les FPS à 60
        Application.targetFrameRate = 60;

        #region Score
        // Charger le meilleur score sauvegardé
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        score = 0;
        ballLeft = 2;   // Le joueur démarre avec 3 balls (il lui en reste donc 2 après celle actuelle)
        #endregion

        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        UpdateUI();

        if (Input.GetKeyDown(KeyCode.Space) && gameOverMenu.activeSelf) PlayAgain();
    }

    // Ajoute un certain montant au score et vérifie si on bat le record.
    public void AddScore(int amount)
    {
        score += amount;

        // Mise à jour du meilleur score
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    // Met à jour l'affichage des scores sur le HUD.
    private void UpdateUI()
    {
        scoreValueText.text = score.ToString("D7");
        bestScoreValueText.text = bestScore.ToString("D7");
        ballLeftText.text = ballLeft.ToString();
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);  // 0 correspond à l'index du main menu
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);  // 1 correspond à l'index de la scène de jeu
    }
}

