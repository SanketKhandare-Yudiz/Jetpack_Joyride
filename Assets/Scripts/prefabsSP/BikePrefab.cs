using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikePrefab : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.gameObject.GetComponent<Player>();
        if(player != null)
        {
            Destroy(gameObject);
        }
    }
}
