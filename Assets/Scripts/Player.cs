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
    public float fallSpeed;
    private float previousMoveSpeed; //
    private float initialMinThrustforce;
    private float initialMaxThrustforce;
    private float initialfallforce;

    private void Start()
    {
        //
        initialMinThrustforce = minThrustforce;
        initialMaxThrustforce = maxThrustforce;
        initialfallforce = fallSpeed;
        previousMoveSpeed = moveSpeed;
    }

    void FixedUpdate()
    {
        movment();
        ClampPlayer();
        if (Input.GetMouseButton(0))
        {
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
        float increaseforce = Mathf.Lerp(minThrustforce, maxThrustforce, jetpackHoldTime);
        player.gravityScale = 1.8f;
        player.AddForce(Vector2.up * increaseforce, ForceMode2D.Force);
        AnimationController.instance.jumpAnimation();
    }

    public override void movment()
    {
        int distance = Mathf.FloorToInt(player.transform.position.x / 150f); //for increase speed 
        float additionalSpeed = distance * 1.5f;
        float currentMoveSpeed = moveSpeed + additionalSpeed;
        Debug.Log("Current Move Speed: " + currentMoveSpeed);
        player.velocity = new Vector2(currentMoveSpeed, player.velocity.y);

        //
        if (currentMoveSpeed > previousMoveSpeed)
        {
            minThrustforce += 5f;
            maxThrustforce += 5f;
            fallSpeed += 5f;
            Debug.Log("fallSpeed:" +fallSpeed);
        }
        // 
        previousMoveSpeed = currentMoveSpeed;
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