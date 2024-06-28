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
        player.gravityScale = 1.5f;
        player.AddForce(Vector2.up * increaseforce, ForceMode2D.Force);
        AnimationController.instance.jumpAnimation();
    }

    public override void movment()
    {
        int distance = Mathf.FloorToInt(player.transform.position.x / 200f);
        float additionalSpeed = distance * 2f;
        float currentMoveSpeed = moveSpeed + additionalSpeed;
        Debug.Log("Current Move Speed: " + currentMoveSpeed);
        player.velocity = new Vector2(currentMoveSpeed, player.velocity.y);
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

//if (distance >= 2f && !isDistancechanged)
//{
//    float adjustedMinThrust = minThrustforce + 5f;
//    float adjustedMaxThrust = maxThrustforce + 5f;

//    minThrustforce = adjustedMinThrust;
//    maxThrustforce = adjustedMaxThrust;

//    Debug.Log("minThrustforce:" + minThrustforce);
//    Debug.Log("maxThrustforce:" + maxThrustforce);

//    isDistancechanged = true;
//}
