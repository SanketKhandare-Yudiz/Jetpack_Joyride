using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildPrefab : MonoBehaviour
{
    public delegate void AddShildScript();
    public static AddShildScript addShildScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
            Debug.Log("Collided");
            addShildScript?.Invoke();
        }
    }
}
