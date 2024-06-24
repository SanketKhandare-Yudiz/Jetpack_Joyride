using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;


    private void OnEnable()
    {
        ShildPrefab.addShildScript += AddShildScript;
        BikePrefab.addBikeScript += AddBikeScript;
        ProfitBirdPrefab.addProfitbirdScript += AddProfitBirdScript;
    }

    private void OnDisable()
    {
        ShildPrefab.addShildScript -= AddShildScript;
        BikePrefab.addBikeScript -= AddBikeScript;
        ProfitBirdPrefab.addProfitbirdScript -= AddProfitBirdScript;
    }

    public void AddShildScript()
    {
        playerScript.enabled = false;
        player.AddComponent<Shild>();
        Debug.Log("ScriptChange");
    }

    public void AddBikeScript()
    {
        playerScript.enabled = false;
        player.AddComponent<Bike>();
    }

    public void AddProfitBirdScript()
    {
        playerScript.enabled = false;
        player.AddComponent<ProfitBird>();
    }

    public void StartPlayerScript()
    {
        player.transform.position = Vector2.zero;
        playerScript.enabled = true;
    }
}
