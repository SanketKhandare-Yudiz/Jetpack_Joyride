using UnityEngine;

public class Player : PlayerActions
{
    public Rigidbody2D player;
    public float thrustforce;
    public float maxThrustforce;
    public float moveSpeed;
    private bool isJetpackActive = false;
    private float jetpackHoldTime = 0f;
    private float decreaseSpeed = 2f;

    void Update()
    {
        movment();
        ClampPlayer();

        if (Input.GetMouseButton(0))
        {
            isJetpackActive = true;
            jetpackHoldTime += Time.deltaTime;
        }
        else
        {
            //isJetpackActive = false;
            //jetpackHoldTime = 0f;

            isJetpackActive = false;
            if (jetpackHoldTime > 0)
            {
                jetpackHoldTime -= Time.deltaTime * decreaseSpeed;
                if (jetpackHoldTime < 0)
                {
                    jetpackHoldTime = 0f;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (isJetpackActive)
        {
            Jump();
        }
    }

    public override void Jump()
    {
        float scaledThrustforce = Mathf.Lerp(thrustforce, maxThrustforce, jetpackHoldTime);
        //player.velocity = new Vector2(player.velocity.x, scaledThrustforce);

        player.AddForce(Vector2.up * scaledThrustforce,ForceMode2D.Force);
        Debug.Log("Scaled Force Value :" + scaledThrustforce);
        AnimationController.instance.jumpAnimation();
    }

    public override void movment()
    {
        //player.velocity = new Vector2(moveSpeed, player.velocity.y);
        player.AddForce(Vector2.right * moveSpeed,ForceMode2D.Force);
    }
}

