using UnityEngine;

public class Shild : PlayerAbility
{
    [SerializeField] private float movespeed = 10f;
    [SerializeField] private float jumpSpeed = 20f;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Player playerScript;
    [SerializeField] private float jetpackHoldTime = 0f;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<Player>();
    }

    private void FixedUpdate()
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
        player.gravityScale = 1.8f;
        player.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
        AnimationController.instance.jumpAnimation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Zapper zapper = collision.transform.gameObject.GetComponent<Zapper>();
        Missile misile = collision.transform.GetComponent<Missile>();
        if (zapper != null || misile != null)
        {
            playerScript.enabled = true;
            Destroy(gameObject);
            Debug.Log("SP Deleted");
        }
    }
}