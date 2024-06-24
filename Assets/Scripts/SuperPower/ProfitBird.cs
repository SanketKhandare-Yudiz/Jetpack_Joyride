using UnityEngine;

public class ProfitBird : PlayerActions
{
    private float movespeed = 15f;
    private float jumspeed =10f;
    private Rigidbody2D player;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        Debug.Log("Player name:"+player.gameObject.name);
    }

    void Update()
    {
        movment();
        ClampPlayer();
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    public override void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumspeed);
    }

    public override void movment()
    {
        player.velocity = new Vector2(movespeed, player.velocity.y);
    }
}
