using UnityEngine;

public class Shild : PlayerAbility
{
    private float movespeed = 5f;
    private float jumpSpeed = 7f;
    private Rigidbody2D player;
    private Player playerScript;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<Player>();
    }

    private void Update()
    {
        movment();
        ClampPlayer();
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    public override void movment()
    {
       player.velocity = new Vector2(movespeed, player.velocity.y);
    }

    public override void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Zapper zapper = collision.transform.gameObject.GetComponent<Zapper>();
        if(zapper != null)
        {
            playerScript.enabled = true;
            Destroy(gameObject);
            Debug.Log("SP Deleted");
        }
    }
}
