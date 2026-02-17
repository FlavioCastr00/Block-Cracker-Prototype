using UnityEngine;

public class PaddleBrick : BasicBrick
{
    private PlayerController playerController;

    void OnEnable()
    {
        playerController = FindFirstObjectByType<PlayerController>().GetComponent<PlayerController>();    
    }

    protected override void TakeDamage()
    {
        durability -= damageToTake;

        if (durability <= 0)
        {
            gameObject.SetActive(false);
            playerController.SetPaddlePowerUpActive();
        }
    }
}
