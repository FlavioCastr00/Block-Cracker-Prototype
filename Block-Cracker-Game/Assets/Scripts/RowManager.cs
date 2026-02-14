using UnityEngine;

public class RowManager : MonoBehaviour
{
    public GameObject[] bricks;

    public void SetBricksActive()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i].SetActive(true);
        }
    }
}
