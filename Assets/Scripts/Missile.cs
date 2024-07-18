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
    private Camera camera;
    Vector2 targetPos;

    private void Update()
    {
        LaunchMissile();
    }

    private void FixedUpdate()
    {
        DisplayMissileIndicator();
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
   
    public void DisplayMissileIndicator()
    {
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        Vector2 missileViewportPosition = camera.WorldToViewportPoint(transform.position);
        Debug.Log("viewpointPosition :-" + missileViewportPosition);

        if (distanceToPlayer <= trackDistance && distanceToPlayer > 15f)
        {
            Debug.Log("Indicator On");
            missileIndicatorGameObject.SetActive(true);
            missileViewportPosition.x = 0.97f;
            missileViewportPosition.y = Mathf.Clamp(missileViewportPosition.y, -3.4f, 4.5f);
            Debug.Log("missile Y Pos :- " + missileViewportPosition.y);
            Vector3 indicatorWorldPosition = camera.ViewportToWorldPoint(new Vector3(missileViewportPosition.x, missileViewportPosition.y, camera.nearClipPlane));
            Debug.Log("worldPointPosition:- " + indicatorWorldPosition);
            missileIndicatorGameObject.transform.position = indicatorWorldPosition;
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
    public void SetCamera(Camera viewportCamera)
    {
        camera = viewportCamera;
    }
}
