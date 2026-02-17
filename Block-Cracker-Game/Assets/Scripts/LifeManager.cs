using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeObjects;
    public GameObject playerBallPool;
    public bool isGameOver = false;

    private int life = 3;
    private int ballCount;

    void Update()
    {
        ballCount = FindObjectsByType<BallBehaviour>(FindObjectsSortMode.None).Length;

        if (ballCount < 1)
        {
            LoseLife(1);
            playerBallPool.GetComponent<PlayerBallPool>().RespawnPlayerBall();
        }
    }

    public void GainLife(int amount)
    {
        if (life == 3)
        {
            return;
        }

        life += amount;

        if (life == 3)
        {
            lifeObjects[0].SetActive(true);
        }

        if (life == 2)
        {
            lifeObjects[1].SetActive(true);
        }
    }

    public void LoseLife(int amount)
    {
        life -= amount;

        if (life == 2)
        {
            lifeObjects[0].SetActive(false);
        }

        if (life == 1)
        {
            lifeObjects[1].SetActive(false);
        }

        if (life == 0)
        {
            lifeObjects[2].SetActive(false);
            isGameOver = true;
        }
    }
}
