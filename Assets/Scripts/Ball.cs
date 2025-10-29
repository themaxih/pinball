using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isBallLaunched;
    public Transform scorePopup;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isBallLaunched = false;
    }

    private void Update()
    {
        if (!isBallLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForceY(Random.Range(120, 130));
            isBallLaunched = true;
        }
    }

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
        transform.position = new Vector3(4.025f, -6, 0);
        isBallLaunched = false;
    }
}
