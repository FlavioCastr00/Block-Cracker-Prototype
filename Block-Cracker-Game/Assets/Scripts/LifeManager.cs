using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeObjects;
    public bool isGameOver = false;

    private int life = 3;

    public void LoseLife(int amount)
    {
        life -= amount;

        if (life == 2)
        {
            lifeObjects[0].SetActive(false);
        }

        if (life == 1)
        {
            lifeObjects[1].SetActive(false);
        }

        if (life == 0)
        {
            lifeObjects[2].SetActive(false);
            isGameOver = true;
        }
    }
}
