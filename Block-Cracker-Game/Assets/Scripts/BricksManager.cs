using UnityEngine;

public class BricksManager : MonoBehaviour
{
    public GameObject[] rows;
    
    private int brickCount;
    private float speed = 2f;
    private Vector3 stopPos = new Vector3(0f, 2f, 0f);
    private Vector3 outOfViewPos = new Vector3(0f, 6.5f, 0f);

    // Update is called once per frame
    void Update()
    {
        brickCount = FindObjectsByType<BasicBrick>(FindObjectsSortMode.None).Length;

        if (brickCount == 0 )
        {
            RespawnBricks();
        }

        if (gameObject.transform.position.y > stopPos.y)
        {
            gameObject.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = stopPos;
        }
    }

    private void RespawnBricks()
    {
        gameObject.transform.position = outOfViewPos;

        for ( int i = 0; i < rows.Length; i++ )
        {
            RowManager row = rows[i].GetComponent<RowManager>();
            row.SetBricksActive();
        }
    }
}