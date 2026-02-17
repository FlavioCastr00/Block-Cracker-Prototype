using UnityEngine;

public class PlayerBallPool : MonoBehaviour
{
    public GameObject playerBall;

    public void RespawnPlayerBall()
    {
        playerBall.SetActive(true);
        playerBall.GetComponent<BallBehaviour>().ResetGame();
    }
}
