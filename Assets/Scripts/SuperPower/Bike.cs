using UnityEngine;

public class Bike : PlayerAbility
{
    public float jumpSpeed;
    public float moveSpeed;
    public Player player;
  
    void Update()
    {
        movment();

        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    public override void Jump()
    {
        player.player.AddForce(Vector2.up * jumpSpeed);
    }

    public override void movment()
    {
        player.player.AddForce(Vector2.right * moveSpeed);
    }
}
