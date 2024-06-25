using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if(player != null)
        {
            Destroy(gameObject);
        }
    }
}
