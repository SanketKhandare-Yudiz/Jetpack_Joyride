using System.Collections.Generic;
using UnityEngine;

public class SpecialPowerSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> superPowersPrefab;
    [SerializeField] private float specialPowerDistance = 10f;
    [SerializeField] private float initialSPPosition = 10f;

    public Player player;

    private List<GameObject> SpecialPower = new List<GameObject>();
    private float nextSPPosition;

    void Start()
    {
        nextSPPosition = initialSPPosition;
        for(int i =0; i<2; i++)
        {
            SpwanSuperPower();
        }
    }

    void Update()
    {
        if (player.transform.position.x > SpecialPower[1].transform.position.x)
        {
            RemoveObstacle();
            SpwanSuperPower();
        }
    }
    public void SpwanSuperPower()
    {
        int randomIndex = Random.Range(0, superPowersPrefab.Count);
        GameObject randomPrefab = superPowersPrefab[randomIndex];
        Vector3 spawnPosition = new Vector3(nextSPPosition, transform.position.y, transform.position.z);
        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        SpecialPower.Add(newObstacle);
        nextSPPosition += specialPowerDistance;
    }

    void RemoveObstacle()
    {
        GameObject specialpower = SpecialPower[0];
        SpecialPower.RemoveAt(0);
        Destroy(specialpower);
    }
}
