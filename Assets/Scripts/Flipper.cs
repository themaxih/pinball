using UnityEngine;

public enum EFlipperType
{
    Left,
    Right
}

public class Flipper : MonoBehaviour
{
    private Rigidbody2D rb;
    private float torque = 17600;

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
        // Lorsque la touche est maintenue, on ajoute du couple au rigidbody pour le faire rotationner. Sinon on en retire
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
