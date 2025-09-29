using UnityEngine;

public enum EFlipperType
{
    Left,
    Right
}

public class Flipper : MonoBehaviour
{
    private Rigidbody2D rb;
    private float torque = 156;

    public KeyCode key;
    public EFlipperType type;

    private void Start()
    {
        // Inverser le couple pour le flipper droit
        if (type == EFlipperType.Right)
        {
            torque *= -1;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            rb.AddTorque(torque);
        }
        else
        {
            rb.AddTorque(-torque);
        }

    }
}
