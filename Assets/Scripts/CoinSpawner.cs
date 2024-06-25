using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    private float nextCoinPosition;
    public Transform player;
    private float initialPosition = 25f;
   

    bool isinstatiated = false;

    private List<GameObject> coins = new List<GameObject>();

    private void Start()
    {
        nextCoinPosition = initialPosition;

        for (int i=0; i<3; i++)
        {
            SpawnCoin();
        }
    }

    void Update()
    {
        if (player.transform.position.x >= coins[1].transform.position.x && !isinstatiated)
        {
            SpawnCoin();
            isinstatiated = true;
        }
    }

    void SpawnCoin()
    {
        float yOffset = Random.Range(4, -3);
        Vector3 spawnPosition = new Vector3(nextCoinPosition, transform.position.y + yOffset, transform.position.z);
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        coins.Add(coin);
        float newDistance = Random.Range(50, 100);
        nextCoinPosition += newDistance;
        isinstatiated = false;
    }
}