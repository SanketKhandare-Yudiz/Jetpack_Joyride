using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : ObstacleSpawner
{
    private float missileSpeed = 25f;
    private float trackDistance = 100f;
    private float launchDistance = 20f;
    private Transform playerTransform;
    private GameObject missileIndicatorGameObject;
    private Vector2 playerPos;
    private Vector2 missilePos;
    Vector2 targetPos;

    private void Update()
    {
        LaunchMissile();
       // DisplayMissileIndicator();
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
            transform.position = Vector2.MoveTowards(missilePos, playerPos, missileSpeed * Time.deltaTime);
            //DisplayMissileIndicator();
        }
    }
    private void DisplayMissileIndicator()
    {
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer <= trackDistance && distanceToPlayer > 15f)
        {
            Debug.Log("Indicator On");
            missileIndicatorGameObject.SetActive(true);
            float targetY = transform.position.y;
            float newY = Mathf.Lerp(missileIndicatorGameObject.transform.position.y, targetY, Time.deltaTime * 20f);
            missileIndicatorGameObject.transform.position = new Vector2(missileIndicatorGameObject.transform.position.x, newY);
        }
        else if (distanceToPlayer <= 15f)
        {
            Debug.Log("Indicator Off");
            missileIndicatorGameObject.SetActive(false);
        }
    }

    private void LaunchMissile()
    {
        if (Vector2.Distance(playerTransform.position, transform.position) <= trackDistance)
        {
            TrackPlayer();
            if(Vector2.Distance(playerTransform.position, transform.position) == 20f)
            {
                targetPos = playerTransform.position;
            }
            Debug.Log("targetPos:" + targetPos);
        }
        if (Vector2.Distance(playerTransform.position, transform.position) <= launchDistance)
        {
            transform.position = Vector2.MoveTowards(missilePos, targetPos, missileSpeed * Time.deltaTime);
        }
         //DisplayMissileIndicator();
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

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
    }
    public void SetMissileIndicatorTransform(GameObject missileIndicator)
    {
        missileIndicatorGameObject = missileIndicator;
    }
}



