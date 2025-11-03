using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody2D rb;
    public bool isBallLaunched;         // Permet de check si la ball a été lancée
    public Transform scorePopup;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        if (!isBallLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForceY(Random.Range(121, 130));
            isBallLaunched = true;

            ScreenShake shake = new ScreenShake(Camera.main, 0.1f, 0.1f);
            shake.StartShake();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isBallLaunched = !collision.CompareTag("Launcher");

        if (collision.CompareTag("DeathZone"))
        {
            Death();
            return; // pas besoin de continuer
        }

        // Dictionnaire
        var scoreMap = new Dictionary<string, EScores>
        {
            { "Bumper", EScores.Bumper },
            { "StarPanel", EScores.StarPanel },
            { "CirclePanel", EScores.CirclePanel },
            { "TrianglePanel", EScores.TrianglePanel },
            { "WallPanel", EScores.WallPanel }
        };

        if (scoreMap.TryGetValue(collision.tag, out EScores scoreType))
        {
            gameManager.AddScore((int)scoreType);

            // Popup
            if (scorePopup != null)
            {
                Transform popup = Instantiate(scorePopup, collision.transform.position, Quaternion.identity);
                var tmp = popup.GetComponent<TextMeshPro>();
                if (tmp != null) tmp.text = ((int)scoreType).ToString();
            }

            // Animation
            Animator anim = collision.GetComponent<Animator>();
            anim?.SetTrigger("Hit");

            // Screen shake uniquement pour les bumpers
            if (collision.CompareTag("Bumper"))
            {
                ScreenShake shake = new ScreenShake(Camera.main, 0.05f, 0.1f);
                shake.StartShake();
            }
        }
    }


    void Death()
    {
        if (gameManager.ballLeft > 0)
        {
            // Placeholder
            transform.position = new Vector3(4.025f, -6, 0);
            gameManager.ballLeft--;
        }
        else
        {
            // Game Over 
            gameManager.GameOver();
        }
    }
}
