using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    private float disappearTimer = 0.3f;

    private void Update()
    {
        float moveYSpeed = 3f;

        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
