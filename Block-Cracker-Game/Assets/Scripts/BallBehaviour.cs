using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Get the collision normal
        Vector3 normal = collision.contacts[0].normal;

        // Reflect velocity along the surface
        Vector3 reflectedVelocity = Vector3.Reflect(rb.linearVelocity, normal).normalized * speed;

        // Paddle influence
        if (collision.gameObject.CompareTag("PlayerRight"))
            reflectedVelocity.x = Random.Range(1f, 3f);

        else if (collision.gameObject.CompareTag("PlayerLeft"))
            reflectedVelocity.x = Random.Range(-3f, -1f);

        rb.linearVelocity = reflectedVelocity;
    }
}
