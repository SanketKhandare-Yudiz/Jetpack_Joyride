using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : Obstacle
{
    private float speed = 15f;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    private void Update()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    { 
        StartCoroutine(LaunchMissile());
    }

    IEnumerator LaunchMissile()
    {
        yield return new WaitForSeconds(2f);
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
