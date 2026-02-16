using UnityEngine;

public class BasicBrick : MonoBehaviour
{
    [SerializeField] protected int durability = 10;
    [SerializeField] protected int damageToTake = 10;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage();
        }
    }

    protected virtual void TakeDamage()
    {
        durability -= damageToTake;

        if (durability <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
