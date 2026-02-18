using Unity.VisualScripting;
using UnityEngine;

public class BasicBrick : MonoBehaviour
{
    [SerializeField] protected int durability = 10;
    [SerializeField] protected int damageToTake = 10;
    [SerializeField] protected int points = 15;

    protected UiManager uiManager;

    protected virtual void OnEnable()
    {
        uiManager = FindFirstObjectByType<UiManager>().GetComponent<UiManager>();
    }

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
            uiManager.UpdateCurrentScore(points);
        }
    }
}
