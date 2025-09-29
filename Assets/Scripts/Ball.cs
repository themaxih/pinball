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
        transform.position = new Vector3(1.25f, 4, 0);
    }
}
