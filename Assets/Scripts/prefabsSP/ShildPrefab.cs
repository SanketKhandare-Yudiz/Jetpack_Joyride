using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildPrefab : MonoBehaviour
{
    public delegate void AddScript();
    public static AddScript addScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.gameObject.GetComponent<Player>();
        if(player != null)
        {
            Destroy(gameObject);
            addScript?.Invoke();
        }
    }
}
