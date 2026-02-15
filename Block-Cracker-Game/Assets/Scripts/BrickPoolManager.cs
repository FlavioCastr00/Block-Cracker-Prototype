using UnityEngine;

public class BrickPoolManager : MonoBehaviour
{
    public GameObject[] bricks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBrickActive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBrickActive()
    {
        int blockChanceRatio = Random.Range(1, 11);

        if (blockChanceRatio <= 2 )
        {
            int randomBlockIndex = Random.Range(1, bricks.Length);
            bricks[randomBlockIndex].SetActive(true);
            return;
        }

        bricks[0].SetActive(true);
    }
}
