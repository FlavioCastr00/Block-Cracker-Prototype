using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private float xBound = 4.25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * moveX * speed *  Time.deltaTime);

        // Handle Game Bounds
        if (gameObject.transform.position.x >  xBound)
        {
            transform.position = new Vector2(xBound, transform.position.y);
        }
        if (gameObject.transform.position.x < -xBound)
        {
            transform.position = new Vector2 (-xBound, transform.position.y);
        }
    }
}
