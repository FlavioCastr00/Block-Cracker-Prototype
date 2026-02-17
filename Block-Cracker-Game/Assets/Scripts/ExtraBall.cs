using UnityEngine;

public class ExtraBall : BallBehaviour
{
    void OnEnable()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        ThrowBall();
    }
    protected override void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;

        // Limit max speed
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        // Limit min speed
        if (velocity.magnitude < minSpeed)
        {
            velocity = velocity.normalized * minSpeed;
        }

        // Set min speed for the Y axis
        if (Mathf.Abs(velocity.y) < minYSpeed)
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

    protected override void ThrowBall()
    {
        Vector2 force = Vector2.zero;

        force.x = Random.Range(-3f, 3f);
        force.y = 1f;

        rb.AddForce(force.normalized * speed);
    }
}
