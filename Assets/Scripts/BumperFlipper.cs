using TMPro;
using UnityEngine;

public class BumperFlipper : MonoBehaviour
{
    [SerializeField] private float additionalImpulse = 0.5f;   // impulsion ajoutée à la ball

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Rigidbody2D rb = collision.attachedRigidbody;
            if (rb == null) return;

            // Calcule une direction de rebond approximative
            // vers la direction opposée au vecteur entre le bumper et la balle.
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            // Applique une force dans cette direction
            rb.AddForce(direction * additionalImpulse, ForceMode2D.Impulse);
        }

    }
}
