using UnityEngine;

public class Launcher : MonoBehaviour
{
    private SpringJoint2D springJoint;
    private Rigidbody2D rb;
    private float force = 0f;          
    public float maxForce = 90f;

    void Start()
    {
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.distance = 1f;
        rb = GetComponent<Rigidbody2D>();

    }

    /*
    void Update()
    {
        force = powerIndex * maxForce;

    }

    private void FixedUpdate()
    {
        if (force != 0)
        {
            springJoint.distance = 1f;
            rb.AddForce(Vector3.up * force);
            force = 0;
        }

        if (pressTime != 0)
        {
            springJoint.distance = 0.8f;
            rb.AddForce(Vector3.down * 400);
        }
    }
    */

}
