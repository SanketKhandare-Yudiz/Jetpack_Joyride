using UnityEngine;

public class PlayerActions : MonoBehaviour
{
  float maxY = 4.3f;
  public virtual void Jump() { }

  public virtual void movment() { }

    public void ClampPlayer()
    {
        float clampedY = Mathf.Clamp(transform.position.y, float.MinValue, maxY);
        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);

            if (transform.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                float force = Mathf.Lerp(0f, 10f, Time.deltaTime);
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<Rigidbody2D>().velocity.x, force);
                Debug.Log("Speed: " + force);
                transform.GetComponent<Rigidbody2D>().gravityScale = 0.5f;

            }
        }
    }
}

//public void ClampPlayer()
//{
//    float clampedY = Mathf.Clamp(transform.position.y, float.MinValue, maxY);
//    transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
//    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
//}