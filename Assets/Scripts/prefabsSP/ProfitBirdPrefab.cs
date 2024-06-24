using UnityEngine;

public class ProfitBirdPrefab : MonoBehaviour
{
    public delegate void AddProfitbirdScript();
    public static AddProfitbirdScript addProfitbirdScript;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.transform.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
            addProfitbirdScript?.Invoke();
        }
    }
}
