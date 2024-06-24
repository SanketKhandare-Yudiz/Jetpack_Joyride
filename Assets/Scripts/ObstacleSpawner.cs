using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> ZapperPrefabs;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject laserPrefab;

    private float initialZapperPosition = 30f;
    private float initialMissilePosition = 300f;
    private float initiallaserPosition = 600f;

    public Transform player; 

    private List<GameObject> zapperlist = new List<GameObject>();
    private List<GameObject> missileList = new List<GameObject>();
    private List<GameObject> laserlist = new List<GameObject>();

    private float nextObstaclePosition;
    private float nextMissilePosition;
    private float nextLaserPosition;

    bool instatiate = false;

    void Start()
    {
        nextObstaclePosition = initialZapperPosition;
        nextMissilePosition = initialMissilePosition;
        nextLaserPosition = initiallaserPosition;

        for (int i = 0; i < 3; i++)
        {
            SpawnZapper();
        }
        SpawnMissile();
    }

    void Update()
    {
        if (player.transform.position.x > zapperlist[2].transform.position.x)
        {
            RemoveZapper();
            SpawnZapper();
            Debug.Log("Spown Zapper");
        }

        if (player.transform.position.x > missileList[0].transform.position.x && !instatiate)
        {
            GameObject missile = missileList[0];
            missileList.RemoveAt(0);
            Destroy(missile);
            SpawnMissile();
            instatiate = true;
        }

        if (player.transform.position.x > 600f && !instatiate)
        {
            SpawnLaser();
            instatiate = true;
            Debug.Log("LaserSpown");
        }
    }

    void SpawnZapper()
    {
        int randomIndex = Random.Range(0, ZapperPrefabs.Count);
        Debug.Log("randomprefabindex:" + randomIndex);
        GameObject randomPrefab = ZapperPrefabs[randomIndex];
        float yoffset = Random.Range(3, -3);
        Vector3 spawnPosition = new Vector3(nextObstaclePosition, transform.position.y + yoffset, transform.position.z);
        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        newObstacle.transform.Translate(Vector2.left * 5f, Space.World);
        zapperlist.Add(newObstacle);
        float obstacleDistance = Random.Range(15, 25);
        nextObstaclePosition += obstacleDistance;
    }

    void RemoveZapper()
    {
        GameObject zapper = zapperlist[0];
        zapperlist.RemoveAt(0);
        Destroy(zapper);
    }
    
    void SpawnMissile()
    {
        float yoffset = Random.Range(4, -3);
        Vector3 spownPosition = new Vector3(nextMissilePosition, transform.position.y + yoffset, transform.position.z);
        Quaternion rotation = Quaternion.Euler(0, 0, 90);
        GameObject newMissile = Instantiate(missilePrefab, spownPosition, rotation);
        missileList.Add(newMissile);
        float newDistance = Random.Range(100, 200);
        nextMissilePosition += newDistance;
        instatiate = false;
    }

    void SpawnLaser()
    {
        float yOffset = Random.Range(4, -3);
        Vector3 spownPosition = new Vector3(nextLaserPosition, transform.position.y + yOffset, transform.position.z);
        GameObject newlaser = Instantiate(laserPrefab, spownPosition, Quaternion.identity);
        laserlist.Add(newlaser);
        float newDistance = Random.Range(300, 400);
        nextLaserPosition += newDistance;
        instatiate = false;
    }
}
//void CleanupMissiles()
//{
//    for (int i = missileList.Count - 1; i >= 0; i--)
//    {
//        if (missileList[i].transform.position.x < player.transform.position.x - 10f)
//        {
//            Destroy(missileList[i]);
//            missileList.RemoveAt(i);
//        }
//    }
//}