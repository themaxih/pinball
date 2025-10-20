using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Ball : MonoBehaviour
{
    public Transform scorePopup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Death();
        }

        if (collision.CompareTag("Bumper"))
        {
            GameManager.score += (int)EScores.Bumper;
            Transform scorePopupInstance = Instantiate(scorePopup, collision.transform.position, Quaternion.identity);
            scorePopupInstance.GetComponent<TextMeshPro>().text = ((int)EScores.Bumper).ToString();
        }
    }

    void Death()
    {
        // Placeholder
        transform.position = new Vector3(Random.Range(-0.25f, 0.25f), 5.85f, 0);
    }
}
