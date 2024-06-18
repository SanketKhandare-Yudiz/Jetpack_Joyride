using UnityEngine;
using UnityEngine.SceneManagement;

public class Zapper : Obstacle
{

    public delegate void DeadAnimation();
    public static DeadAnimation deadAnimation;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if(player != null)
        {
            deadAnimation?.Invoke();
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
