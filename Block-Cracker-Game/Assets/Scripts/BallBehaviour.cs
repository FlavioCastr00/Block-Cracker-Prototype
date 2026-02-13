using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    private Rigidbody rb;
    private float maxSpeed = 8f;
    private float verticalWallsImpulse = 0.02f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector2 force = Vector2.zero;

        force.x = 0f;
        force.y = 1f;

        rb.AddForce(force.normalized * speed);
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector2 newForce = Vector2.zero;

        if (collision.gameObject.CompareTag("PlayerRight"))
        {
            newForce.x = Random.Range(4f, 6f);
        }
        else if (collision.gameObject.CompareTag("PlayerLeft"))
        {
            newForce.x = Random.Range(-6f, -4f);
        }
        else if (collision.gameObject.CompareTag("RightWall"))
        {
            newForce.x = -verticalWallsImpulse;
        }
        else if (collision.gameObject.CompareTag("LeftWall")) {
            newForce.x = verticalWallsImpulse;
        }
        Debug.Log(rb.linearVelocity.magnitude);
        rb.AddForce(newForce.normalized, ForceMode.Impulse);
    }
}
