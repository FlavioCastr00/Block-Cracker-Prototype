using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LifeManager lifeManager;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float powerUpCountDown = 7.0f;

    private Vector3 originalScale = new Vector3(2.0f, 0.3f, 1.0f);
    private Vector3 powerUpScale = new Vector3(3.0f, 0.3f, 1.0f);
    private float xBound = 4.25f;
    private float powerUpTimer = 0.0f;
    private bool isPowerUpActive = false;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        if (lifeManager.isGameOver == false)
        {
            transform.Translate(Vector2.right * moveX * speed * Time.deltaTime);
        }

        // Handle Game Bounds
        if (gameObject.transform.position.x >  xBound)
        {
            transform.position = new Vector2(xBound, transform.position.y);
        }
        if (gameObject.transform.position.x < -xBound)
        {
            transform.position = new Vector2 (-xBound, transform.position.y);
        }

        if (isPowerUpActive && powerUpTimer > 0.0f)
        {
            powerUpTimer -= Time.deltaTime;
        }

        if (powerUpTimer < 0.0f)
        {
            DisablePowerUp();
        }
    }

    public void SetPaddlePowerUpActive()
    {
        gameObject.transform.localScale = powerUpScale;
        isPowerUpActive = true;
        powerUpTimer = powerUpCountDown;
    }

    private void DisablePowerUp()
    {
        gameObject.transform.localScale = originalScale;
        isPowerUpActive = false;
    }
}
