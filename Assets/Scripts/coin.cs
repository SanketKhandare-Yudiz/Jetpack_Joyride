using UnityEngine;

public class coin : MonoBehaviour
{
    private int coinCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if (player != null)
        {
            coinCount++;
            Debug.Log("collected Coins:" + coinCount++);
            Destroy(gameObject);
            Debug.Log("triggered");
        }
    }
}
