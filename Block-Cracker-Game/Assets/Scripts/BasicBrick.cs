using UnityEngine;

public class BasicBrick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameObject.SetActive(false);
        }
    }
}
