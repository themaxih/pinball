using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Death();
        }
    }

    void Death()
    {
        // Placeholder
        transform.position = new Vector3(Random.Range(-0.25f, 0.25f), 5.85f, 0);
    }
}
