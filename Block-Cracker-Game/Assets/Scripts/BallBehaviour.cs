using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public LifeManager lifeManager;

    [SerializeField] private float speed = 3.0f;

    private Rigidbody rb;
    private Vector3 ballSpawnPoint = new Vector3(0, -2, 0);
    private float maxSpeed = 8f;
    private float minYSpeed = 1f;
    private float verticalWallsImpulse = 0.01f;
    private bool isGamePaused;

    void Start()
    {
        isGamePaused = true;

        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
    }

    void Update()
    {
        if (isGamePaused && Input.GetKeyDown(KeyCode.UpArrow))
        {
            ThrowBall();
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;

        // Limit max speed
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        
        // Set min speed for the Y axis
        if (Mathf.Abs(velocity.y) < minYSpeed && !isGamePaused)
        {
            float direction = Mathf.Sign(velocity.y);

            if (direction == 0)
            {
                direction = 1;
            }

            velocity.y = direction * minYSpeed;
        }

        rb.linearVelocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector2 newForce = Vector2.zero;

        if (collision.gameObject.CompareTag("PlayerRight"))
        {
            newForce.x = Random.Range(3f, 5f);
        }
        else if (collision.gameObject.CompareTag("PlayerLeft"))
        {
            newForce.x = Random.Range(-5f, -3f);
        }
        else if (collision.gameObject.CompareTag("RightWall"))
        {
            newForce.x = -verticalWallsImpulse;
        }
        else if (collision.gameObject.CompareTag("LeftWall")) {
            newForce.x = verticalWallsImpulse;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            ResetGame();
            lifeManager.LoseLife(1);
        }

        Debug.Log(rb.linearVelocity.magnitude);
        rb.AddForce(newForce.normalized, ForceMode.Impulse);
    }

    private void ThrowBall()
    {
        isGamePaused = false;

        Vector2 force = Vector2.zero;

        force.x = 0f;
        force.y = 1f;

        rb.AddForce(force.normalized * speed);
    }

    private void ResetGame()
    {
        isGamePaused = true;
        rb.linearVelocity = Vector3.zero;
        gameObject.transform.position = ballSpawnPoint;
    }
}
