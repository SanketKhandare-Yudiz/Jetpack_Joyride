using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    public List<GameObject> coinPrefab;
    private float nextCoinPosition;
    public Transform player;
    private float initialPosition = 25f;

    private List<GameObject> coins = new List<GameObject>();

    private void Start()
    {
        nextCoinPosition = initialPosition;

        for (int i = 0; i < 3; i++)
        {
            SpawnCoin();
        }
    }

    void Update()
    {
        if (player.transform.position.x > coins[1].transform.position.x)
        {
            GameObject coin = coins[0];
            coins.RemoveAt(0);
            Destroy(coin);
            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        int randomIndex = Random.Range(0, coinPrefab.Count);
        GameObject randomPrefab = coinPrefab[randomIndex];
        float yOffset = Random.Range(-2, -1);  
        Vector3 spawnPosition = new Vector3(nextCoinPosition, transform.position.y + yOffset, transform.position.z);
        GameObject coin = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        coins.Add(coin);
        float newDistance = Random.Range(50, 100);
        nextCoinPosition += newDistance;
    }
}
