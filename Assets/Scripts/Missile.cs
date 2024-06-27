using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : MonoBehaviour
{
    private float moveSpeed = 15f;
    private float trackDistance = 50f;
    private Transform playerTransform;

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
    }

    private void Update()
    {
        if(playerTransform.position.x > trackDistance)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTransform.position - transform.position, trackDistance);
        Debug.Log("Hit to the player");

        if (hit.collider != null)
        {
            Vector2 playerPos = playerTransform.position;
            Vector2 missilePos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = playerPos - missilePos;
            //direction = direction.normalized;
            transform.position = Vector2.MoveTowards(missilePos, playerPos, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
