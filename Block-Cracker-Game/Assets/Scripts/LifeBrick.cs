using UnityEngine;

public class LifeBrick : BasicBrick
{
    private LifeManager LifeManager;

    void OnEnable()
    {
        LifeManager = FindFirstObjectByType<LifeManager>().GetComponent<LifeManager>();    
    }

    protected override void TakeDamage()
    {
        durability -= damageToTake;

        if (durability <= 0)
        {
            gameObject.SetActive(false);
            LifeManager.GainLife(1);
        }
    }
}
