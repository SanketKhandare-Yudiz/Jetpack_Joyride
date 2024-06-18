using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs; 
    [SerializeField] private float obstacleDistance = 10f;
    [SerializeField] private float initialObstaclePosition = 10f; 

    public Player player; 

    private List<GameObject> obstacles = new List<GameObject>();
    private float nextObstaclePosition; 

    void Start()
    {
        nextObstaclePosition = initialObstaclePosition;
        for (int i = 0; i < 3; i++)
        {
            SpawnObstacle();
        }
    }

    void Update()
    {
        if (player.transform.position.x > obstacles[2].transform.position.x)
        {
            RemoveObstacle();
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Count);
        GameObject randomPrefab = obstaclePrefabs[randomIndex];
        Vector3 spawnPosition = new Vector3(nextObstaclePosition, transform.position.y, transform.position.z);
        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        obstacles.Add(newObstacle); 
        nextObstaclePosition += obstacleDistance;
    }

    void RemoveObstacle()
    {
        GameObject obsatcle = obstacles[0];
        obstacles.RemoveAt(0);
        Destroy(obsatcle);
    }
}
