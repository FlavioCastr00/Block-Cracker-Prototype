using UnityEngine;

public class BrickPoolManager : MonoBehaviour
{
    public GameObject[] bricks;

    [SerializeField] private int specialBrickChance = 10;

    public void SetBrickActive()
    {
        int roll = Random.Range(1, specialBrickChance + 1);

        if (roll == 1 )
        {
            int randomBlockIndex = Random.Range(1, bricks.Length);
            bricks[randomBlockIndex].SetActive(true);
            return;
        }

        bricks[0].SetActive(true);
    }
}
