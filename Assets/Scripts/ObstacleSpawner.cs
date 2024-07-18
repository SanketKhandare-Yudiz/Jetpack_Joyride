//using System.Collections.Generic;
//using UnityEngine;

//public class ObstacleSpawner : SpawnManager
//{
//    [SerializeField] private List<GameObject> ZapperPrefabs;
//    [SerializeField] private GameObject missilePrefab;
//    [SerializeField] private GameObject missileIndicator;
//    [SerializeField] private GameObject laserPrefab;

//    private float initialZapperPosition = 30f;
//    private float initialMissilePosition = 200f;

//    public Transform player;

//    private List<GameObject> zapperlist = new List<GameObject>();
//    private List<GameObject> missileList = new List<GameObject>();

//    private float nextZapperPosition;
//    private float nextMissilePosition;
//    public Camera mainCamera;


//    void Start()
//    {
//        nextZapperPosition = initialZapperPosition;
//        nextMissilePosition = initialMissilePosition;
//        for (int i = 0; i < 2; i++)
//        {
//            SpawnZapper();
//        }
//        SpawnMissile();
//    }

//    void Update()
//    {
//        if (player.transform.position.x > zapperlist[1].transform.position.x)
//        {
//            RemoveZapper();
//            SpawnZapper();
//            Debug.Log("Spawn Zapper");
//        }
//        if (player.transform.position.x > missileList[0].transform.position.x + 10f && missileList[0])
//        {
//            RemoveMissile();
//            SpawnMissile();
//            Debug.Log("missile Spawned");
//        }
//    }

//    void SpawnZapper()
//    {
//        int randomIndex = Random.Range(0, ZapperPrefabs.Count);
//        Debug.Log("randomprefabindex:" + randomIndex);
//        GameObject randomPrefab = ZapperPrefabs[randomIndex];
//        Vector3 spawnPosition = new Vector3(nextZapperPosition, transform.position.y, transform.position.z);
//        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
//        zapperlist.Add(newObstacle);

//        Transform childTransform = randomPrefab.transform.GetChild(0);
//        float childPos = childTransform.localPosition.x;
//        //int myInt = (int)childPos;
//        Debug.Log("child Pos :" + childPos);

//        float obstacleDistance = Random.Range(childPos + 10f, childPos + 13f);
//        nextZapperPosition += obstacleDistance;
//    }

//    private void RemoveZapper()
//    {
//        GameObject zapper = zapperlist[0];
//        zapperlist.RemoveAt(0);
//        Destroy(zapper);
//    }

//    void SpawnMissile()
//    {
//        //float yoffset = Random.Range(4, -3);
//        Vector3 spownPosition = new Vector3(nextMissilePosition, transform.position.y, transform.position.z);
//        Quaternion rotation = Quaternion.Euler(0, 0, 90);
//        GameObject newMissile = Instantiate(missilePrefab, spownPosition, rotation);

//        Missile missile = newMissile.GetComponent<Missile>();
//        if (missile != null)
//        {
//            missile.SetPlayerTransform(player);
//            missile.SetMissileIndicatorTransform(missileIndicator);
//            missile.SetCamera(mainCamera);
//        }
//        missileList.Add(newMissile);
//        float newDistance = Random.Range(100, 150);
//        nextMissilePosition += newDistance;
//    }

//    private void RemoveMissile()
//    {
//        GameObject missile = missileList[0];
//        missileList.RemoveAt(0);
//        Debug.Log("Destroy");
//        Destroy(missile);

//    }
//}
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : SpawnManager
{
    [SerializeField] private List<GameObject> zapperPrefabs;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject missileIndicator;
    [SerializeField] private GameObject laserPrefab;

    private float initialZapperPosition = 30f;
    private float initialMissilePosition = 200f;

    public Transform player;

    private List<GameObject> zapperList = new List<GameObject>();
    private List<GameObject> missileList = new List<GameObject>();

    private float nextZapperPosition;
    private float nextMissilePosition;

    public Camera mainCamera;

    void Start()
    {
        nextZapperPosition = initialZapperPosition;
        nextMissilePosition = initialMissilePosition;
        for (int i = 0; i < 2; i++)
        {
            SpawnZapper();
        }
        SpawnZapper();
        SpawnMissile();
    }

    void Update()
    {
        if (player.transform.position.x > zapperList[0].transform.position.x +20f && zapperList[0])
        {
            RemoveZapper();
            SpawnZapper();
            Debug.Log("Spawn Zapper");
        }
        if (player.transform.position.x > missileList[0].transform.position.x + 10f && missileList[0])
        {
            RemoveMissile();
            SpawnMissile();
            Debug.Log("missile Spawned");
        }
    }

    void SpawnZapper()
    {
        int randomIndex = Random.Range(0, zapperPrefabs.Count);
        GameObject randomPrefab = zapperPrefabs[randomIndex];
        int spawnPointIndex = Random.Range(0, obstacleSpawnPoints.Length);
        Transform spawnPoint = GetObstacleSpawnPoint(spawnPointIndex);


        GameObject newObstacle = Instantiate(randomPrefab, spawnPoint.position, Quaternion.identity);
        zapperList.Add(newObstacle);
        float obstacleDistance = Random.Range(10f, 13f); 
        nextZapperPosition += 30f;
    }

    private void RemoveZapper()
    {
        if (zapperList.Count > 0)
        {
            GameObject zapper = zapperList[0];
            zapperList.RemoveAt(0);
            Destroy(zapper);
        }
    }

    void SpawnMissile()
    {
        int spawnPointIndex = Random.Range(0, obstacleSpawnPoints.Length);
        Transform spawnPoint = GetObstacleSpawnPoint(spawnPointIndex);



        Vector3 spawnPosition = new Vector3(nextMissilePosition, spawnPoint.position.y, spawnPoint.position.z);
        Quaternion rotation = Quaternion.Euler(0, 0, 90);
        GameObject newMissile = Instantiate(missilePrefab, spawnPosition, rotation);

        Missile missile = newMissile.GetComponent<Missile>();
        if (missile != null)
        {
            missile.SetPlayerTransform(player);
            missile.SetMissileIndicatorTransform(missileIndicator);
            missile.SetCamera(mainCamera);
        }
        missileList.Add(newMissile);

        float newDistance = Random.Range(100, 150);
        nextMissilePosition += newDistance;

    }

    private void RemoveMissile()
    {
        if (missileList.Count > 0)
        {
            GameObject missile = missileList[0];
            missileList.RemoveAt(0);
            Destroy(missile);
        }
    }
}
