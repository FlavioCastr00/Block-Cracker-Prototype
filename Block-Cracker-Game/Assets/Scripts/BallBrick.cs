using UnityEngine;

public class BallBrick : BasicBrick
{
    private BallsPool ballsPool;

    void OnEnable()
    {
        ballsPool = FindFirstObjectByType<BallsPool>().GetComponent<BallsPool>();  
    }

    protected override void TakeDamage()
    {
        durability -= damageToTake;

        if (durability <= 0)
        {
            gameObject.SetActive(false);
            ballsPool.GetBall();
        }
    }
}
