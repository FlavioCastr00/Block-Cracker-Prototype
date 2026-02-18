using UnityEngine;

public class BallBrick : BasicBrick
{
    private BallsPool ballsPool;

    protected override void OnEnable()
    {
        base.OnEnable();
        ballsPool = FindFirstObjectByType<BallsPool>().GetComponent<BallsPool>();
    }

    protected override void TakeDamage()
    {
        durability -= damageToTake;

        if (durability <= 0)
        {
            gameObject.SetActive(false);
            uiManager.UpdateCurrentScore(points);
            ballsPool.GetBall();
        }
    }
}
