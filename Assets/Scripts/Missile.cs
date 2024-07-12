using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : ObstacleSpawner
{
    private float moveSpeed = 15f;
    private float trackDistance = 250f;
    private Transform playerTransform;
    private Vector2 playerPos;
    private Vector2 missilePos;
    float lanchPoint = 260f;
    Vector2 pos;

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
    }

    private void Update()
    {
        if (playerTransform.position.x > trackDistance)
        {
            LaunchMissile();
        }
    }

    private void TrackPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTransform.position - transform.position, 50f);
        Debug.Log("Hit to the player");

        if (hit.collider != null)
        {
            playerPos = playerTransform.position;
            missilePos = new Vector2(transform.position.x, transform.position.y);
            Debug.Log("missilePos :- " + missilePos);
        }
    }
    
    private void LaunchMissile()
    {
        //if (playerTransform.position.x > 270f)
        //{
        //    TrackPlayer();
        //    pos = playerTransform.position;
        //    Debug.Log("inside the block");
        //}
        TrackPlayer();
        if(playerPos != Vector2.zero)
        {
            transform.position = Vector2.MoveTowards(missilePos, pos, moveSpeed * Time.deltaTime);
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
