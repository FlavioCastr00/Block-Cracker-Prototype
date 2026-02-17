using UnityEngine;

public class BallsPool : MonoBehaviour
{
    public GameObject[] ballsPool;

    private int ballsPoolIndex = 0;

    public void GetBall()
    {
        if (ballsPoolIndex >= ballsPool.Length)
        {
            ballsPoolIndex = 0;
        }

        ballsPool[ballsPoolIndex].gameObject.transform.position = transform.position;
        ballsPool[ballsPoolIndex].gameObject.SetActive(true);

        ballsPoolIndex++;
    }
}
