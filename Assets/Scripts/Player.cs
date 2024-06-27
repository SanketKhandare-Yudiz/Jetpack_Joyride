using UnityEngine;

public class Player : PlayerActions
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float minThrustforce;
    [SerializeField] private float maxThrustforce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private ParticleSystem jetPackflame;
    //private bool JetpackActive = false;
    private float jetpackHoldTime = 0f;
    public float fallSpeed ;


    void FixedUpdate()
    {
        movment();
        ClampPlayer();
        if (Input.GetMouseButton(0))
        {
            player.gravityScale = 1.5f;
            //JetpackActive = true;
            Jump();
            jetpackHoldTime += Time.deltaTime * 1.5f;
            jetPackflame.Play();
        }
        else
        {
            //JetpackActive = false;
            Fall();
            jetpackHoldTime -= Time.deltaTime;
            if (jetpackHoldTime < 0)
            {
                jetpackHoldTime = 0f;
            }

            jetPackflame.Stop();
        }
    }

    public override void Jump()
    {
        float increaseforce = Mathf.Lerp(minThrustforce, maxThrustforce, jetpackHoldTime - Time.deltaTime);
        player.AddForce(Vector2.up * increaseforce,ForceMode2D.Force);
        AnimationController.instance.jumpAnimation();
    }

    public override void movment()
    {
        player.velocity = new Vector2(moveSpeed, player.velocity.y);
    }

    public void Fall()
    {
        float decreaseforce = Mathf.Lerp(0f, fallSpeed, jetpackHoldTime);
        player.AddForce(Vector2.down * decreaseforce, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            AnimationController.instance.RunAnimation();
        }
    }
}

