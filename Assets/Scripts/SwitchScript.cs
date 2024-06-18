using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;

    private void OnEnable()
    {
        ShildPrefab.addScript += ChangeScripts;
    }

    private void OnDisable()
    {
        ShildPrefab.addScript -= ChangeScripts;
    }

    public void ChangeScripts()
    {
        playerScript.enabled = false;
        player.AddComponent<Shild>();
        Debug.Log("ScriptChange");
    }
}
