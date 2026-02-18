using UnityEngine;

public class PaddleBrick : BasicBrick
{
    private PlayerController playerController;

    protected override void OnEnable()
    {
        base.OnEnable();
        playerController = FindFirstObjectByType<PlayerController>().GetComponent<PlayerController>();
    }

    protected override void TakeDamage()
    {
        durability -= damageToTake;

        if (durability <= 0)
        {
            gameObject.SetActive(false);
            uiManager.UpdateCurrentScore(points);
            playerController.SetPaddlePowerUpActive();
        }
    }
}
