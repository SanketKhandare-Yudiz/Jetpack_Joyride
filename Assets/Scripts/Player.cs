using UnityEngine;

public class Player : PlayerActions
{
    public Rigidbody2D player;
   
    public float jumpSpeed;
    public float moveSpeed;
    float maxY = 4f;
    
    void Update()
    {
        movment();
        ClampPlayer();
        if (Input.GetMouseButton(0))
        { 
            Jump();
        }
    }

    public override void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        AnimationController.instance.jumpAnimation();
        //Debug.Log("Jump");
    }

    void ClampPlayer()
    {
        float clampedY = Mathf.Clamp(transform.position.y, float.MinValue, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    public override void movment()
    {
        //animator.SetBool("isRun",true);
        player.velocity = new Vector2(moveSpeed, player.velocity.y);
    }
}