using UnityEngine;

public class LifeBrick : BasicBrick
{
    private LifeManager LifeManager;

    protected override void OnEnable()
    {
        base.OnEnable();
        LifeManager = FindFirstObjectByType<LifeManager>().GetComponent<LifeManager>();
    }

    protected override void TakeDamage()
    {
        durability -= damageToTake;

        if (durability <= 0)
        {
            gameObject.SetActive(false);
            uiManager.UpdateCurrentScore(points);
            LifeManager.GainLife(1);
        }
    }
}
