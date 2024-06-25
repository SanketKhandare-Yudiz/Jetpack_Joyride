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

    public ParticleSystem jetPackflame;

    void Update()
    {
        movment();
        ClampPlayer();

        if (Input.GetMouseButton(0))
        {
            isJetpackActive = true;
            jetpackHoldTime += Time.deltaTime;
            jetPackflame.Play();
        }
        else
        {
            isJetpackActive = false;
            jetpackHoldTime = 1.5f;

            isJetpackActive = false;
            if (jetpackHoldTime > 0)
            {
                jetpackHoldTime -= Time.deltaTime * decreaseSpeed;
                if (jetpackHoldTime < 0)
                {
                    jetpackHoldTime = 0f;
                }
            }
            jetPackflame.Stop();
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
        float increaseforce = Mathf.Lerp(thrustforce, maxThrustforce, jetpackHoldTime);
        player.AddForce(Vector2.up * increaseforce,ForceMode2D.Force);
        Debug.Log("Force Value :" + increaseforce);
        AnimationController.instance.jumpAnimation();
    }

    public override void movment()
    {
        player.velocity = new Vector2(moveSpeed, player.velocity.y);
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            AnimationController.instance.RunAnimation();
            Debug.Log("OnGround");
        }
    }
}

